## Compiling problems: ##

Maybe, you encountered a message like this,
at the command "nant -buildfile:build-files/linux.build".
```
The type or namespace name `Gtk' could not be found in the global namespace (are you missing an assembly reference?)
```
The problem is, that pkg-config can't find one or more needed libraries,
So you have to adapt the file "linux.build"<br> in the directory "build-files".<br><br>
Open the file "linux.build" with a text-editor and look for these two blocks:<br>
<br>
1. Block:<br>
<pre><code>&lt;references&gt;<br>
  &lt;include name="../bin/libarduinotty.dll"/&gt;<br>
  &lt;include name="gdk-sharp.dll"/&gt;<br>
  &lt;include name="glib-sharp.dll"/&gt;<br>
  &lt;include name="gtk-sharp.dll"/&gt;<br>
  &lt;include name="Mono.Posix.dll"/&gt;<br>
  &lt;include name="System.dll"/&gt;<br>
  &lt;include name="System.Xml.dll"/&gt;<br>
  &lt;include name="pango-sharp.dll"/&gt;<br>
&lt;/references&gt;<br>
</code></pre>
2. Block<br>
<pre><code>&lt;references&gt;<br>
  &lt;include name="gdk-sharp.dll"/&gt;<br>
  &lt;include name="glib-sharp.dll"/&gt;<br>
  &lt;include name="gtk-sharp.dll"/&gt;<br>
  &lt;include name="Mono.Posix.dll"/&gt;<br>
  &lt;include name="System.dll"/&gt;<br>
  &lt;include name="System.Xml.dll"/&gt;<br>
  &lt;include name="pango-sharp.dll"/&gt;<br>
&lt;/references&gt;<br>
</code></pre>
You have to declare the full path of every listed library, except for the library "libarduinotty.dll".<br>
Use "locate" to find out the full paths of these libraries.<br><br>
Example:<br>
<pre><code>locate gtk-sharp.dll<br>
</code></pre>
For Ubuntu 11.10 the blocks would look like this:<br>
<br>
1. Block:<br>
<pre><code>&lt;references&gt;<br>
  &lt;include name="../bin/libarduinotty.dll"/&gt;<br>
  &lt;include name="/usr/lib/cli/gdk-sharp-2.0/gdk-sharp.dll"/&gt;<br>
  &lt;include name="/usr/lib/cli/glib-sharp-2.0/glib-sharp.dll"/&gt;<br>
  &lt;include name="/usr/lib/cli/gtk-sharp-2.0/gtk-sharp.dll"/&gt;<br>
  &lt;include name="/usr/lib/mono/2.0/Mono.Posix.dll"/&gt;<br>
  &lt;include name="/usr/lib/mono/4.0/System.dll"/&gt;<br>
  &lt;include name="/usr/lib/mono/4.0/System.Xml.dll"/&gt;<br>
  &lt;include name="/usr/lib/cli/pango-sharp-2.0/pango-sharp.dll"/&gt;<br>
&lt;/references&gt;<br>
</code></pre>
2. Block:<br>
<pre><code>&lt;references&gt;<br>
  &lt;include name="/usr/lib/cli/gdk-sharp-2.0/gdk-sharp.dll"/&gt;<br>
  &lt;include name="/usr/lib/cli/glib-sharp-2.0/glib-sharp.dll"/&gt;<br>
  &lt;include name="/usr/lib/cli/gtk-sharp-2.0/gtk-sharp.dll"/&gt;<br>
  &lt;include name="/usr/lib/mono/2.0/Mono.Posix.dll"/&gt;<br>
  &lt;include name="/usr/lib/mono/4.0/System.dll"/&gt;<br>
  &lt;include name="/usr/lib/mono/4.0/System.Xml.dll"/&gt;<br>
  &lt;include name="/usr/lib/cli/pango-sharp-2.0/pango-sharp.dll"/&gt;<br>
&lt;/references&gt;<br>
</code></pre>
When you're ready, save this file.<br><br>
Now you can execute the command "nant -buildfile:build-files/linux.build"<br>
to compile "Arduino TTY v0.2" and "nant -buildfile:build-files/linux.build install"<br>
to install it.<br><br>
Please send me your your "linux.build" with the information, which linux system you're using, via <a href='mailto:arduinotty@gmail.com'>E-Mail</a> to me.<br><br>
This would be nice, because I can add these files into the next release of "Arduino TTY".