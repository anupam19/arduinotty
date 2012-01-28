;--------------------------------
;Include Modern UI

  !include "MUI2.nsh"

;--------------------------------
;General

  ;Name and file
  Name "Arduino TTY"
  OutFile "arduinotty_v0.2.exe"

  ;Default installation folder
  InstallDir "$PROGRAMFILES\Arduino TTY"

  ;Get installation folder from registry if available
  InstallDirRegKey HKCU "Software\arduinotty" "InstallDir"

  ;Request application privileges for Windows Vista
  RequestExecutionLevel admin

;--------------------------------
;Interface Settings

  !define MUI_ABORTWARNING
  !define GTK_VERSION "2.12.10"
  !define GTK_URL "http://ftp.novell.com/pub/mono/gtk-sharp/gtk-sharp-2.12.10.win32.msi"
  !define NET_VERSION "4.0.0"
  !define NET_URL "http://www.microsoft.com/downloads/info.aspx?na=41&SrcFamilyId=0A391ABD-25C1-4FC0-919F-B21F31AB88B7&SrcDisplayLang=en&u=http%3a%2f%2fdownload.microsoft.com%2fdownload%2f9%2f5%2fA%2f95A9616B-7A37-4AF6-BC36-D6EA96C8DAAE%2fdotNetFx40_Full_x86_x64.exe"

;--------------------------------
;Pages

  !insertmacro MUI_PAGE_WELCOME
  !insertmacro MUI_PAGE_DIRECTORY
  !insertmacro MUI_PAGE_INSTFILES
  !insertmacro MUI_PAGE_FINISH

  !insertmacro MUI_UNPAGE_WELCOME
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES
  !insertmacro MUI_UNPAGE_FINISH

;--------------------------------
;Languages

  !insertmacro MUI_LANGUAGE "English"

;--------------------------------
;Installer Sections

Icon "${NSISDIR}\contrib\graphics\icons\orange-install.ico"
UninstallIcon "${NSISDIR}\contrib\graphics\icons\orange-uninstall.ico"

Section "Arduino TTY" SECGPH

  RMDir /r "$INSTDIR"
  CreateDirectory "$INSTDIR"
  Call DetectNet

  Call DetectGtk

  SetOutPath "$INSTDIR"

  File arduinotty.exe
  File libarduinotty.dll
  File arduinotty.png
  File arduinotty.ico
  File /r locale

  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\arduinotty" "DisplayName" "Arduino TTY"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\arduinotty" "UninstallString" '"$INSTDIR\Uninstall.exe""'

  CreateDirectory "$SMPROGRAMS\Arduino TTY"
  CreateShortCut "$SMPROGRAMS\Arduino TTY\Arduino TTY.lnk" "$INSTDIR\arduinotty.exe" "" "$INSTDIR\arduinotty.ico" "0" ""
  CreateShortCut "$SMPROGRAMS\Arduino TTY\Uninstall Arduino TTY.lnk" "$INSTDIR\Uninstall.exe"

  ;Create uninstaller
  WriteUninstaller "$INSTDIR\Uninstall.exe"

SectionEnd

;--------------------------------
;Descriptions

  ;Language strings
  LangString DESC_SecDummy ${LANG_ENGLISH} "arduinotty."

  ;Assign language strings to sections
  !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
    !insertmacro MUI_DESCRIPTION_TEXT ${SecDummy} $(DESC_SecDummy)
  !insertmacro MUI_FUNCTION_DESCRIPTION_END

;--------------------------------
;Uninstaller Section



Section "Uninstall"
  Delete "$INSTDIR\arduinotty.exe"
  Delete "$INSTDIR\libarduinotty.dll"
  Delete "$INSTDIR\arduinotty.png"
  Delete "$INSTDIR\arduinotty.ico"
  Delete "$INSTDIR\locale\de\LC_MESSAGES\arduinotty.mo"
  Delete "$INSTDIR\locale\en\LC_MESSAGES\arduinotty.mo"
  RMDir "$INSTDIR\locale\de\LC_MESSAGES\"
  RMDir "$INSTDIR\locale\en\LC_MESSAGES\"
  RMDir "$INSTDIR\locale\de\"
  RMDir "$INSTDIR\locale\en\"
  RMDir "$INSTDIR\locale"
  Delete "$INSTDIR\Uninstall.exe"
  RMDir "$INSTDIR"
  Delete "$SMPROGRAMS\Arduino TTY\Arduino TTY.lnk"
  Delete "$SMPROGRAMS\Arduino TTY\Uninstall Arduino TTY.lnk"
  RMDir "$SMPROGRAMS\Arduino TTY"

  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\arduinotty"
  DeleteRegKey /ifempty HKCU "Software\arduinotty"

SectionEnd

Function GetGtk
        MessageBox MB_OK "Arduino TTY uses Gtk# ${GTK_VERSION}, it will now \
                         be downloaded and installed."
 
        StrCpy $2 "$TEMP\gtk-sharp-2.12.10.win32.msi"
        nsisdl::download /TIMEOUT=30000 ${GTK_URL} $2
        Pop $R1 ;Get the return value
                StrCmp $R1 "success" +3
                MessageBox MB_OK "Download failed: $R1"
                Quit
        ExecWait '"msiexec" /i "$2"  /passive'
        Delete $2
FunctionEnd
 
 
Function DetectGtk
  ReadRegStr $2 HKLM "SOFTWARE\Novell\GtkSharp\Version" ""
  StrCmp $2 "" download done
  download:
  	Call GetGtk
  done:
FunctionEnd

Function GetNet
        MessageBox MB_OK "Arduino TTY uses .Net Framework 4.0, it will now \
                         be downloaded and installed."
 
        StrCpy $2 "$TEMP\dotNetFx40_Full_x86_x64.exe"
        nsisdl::download /TIMEOUT=30000 ${NET_URL} $2
        Pop $R1 ;Get the return value
                StrCmp $R1 "success" +3
                MessageBox MB_OK "Download failed: $R1"
                Quit
        ExecWait "$2 /norestart /passive /showfinalerror"
        Delete $2
FunctionEnd

Function DetectNet
	  ;Check for .Net 4.0
	ReadRegDWORD $0 HKLM "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Client" Install
	IntOp $8 $0 & 1
	IntCmp $8 1 done noDotNet done 

	noDotNet: 
		Call GetNet
	done:
FunctionEnd