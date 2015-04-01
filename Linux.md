## Download and installation: Linux ##

If you're using Ubuntu Linux 11.10, then you can use the debian-package.<br>
Else you have to build "Arduino TTY v0.2" by yourself, I've made a tarball for this.<br>
<br>
<ul><li><h3>Ubuntu 11.10</h3>
</li></ul><blockquote>Just write the command below into your terminal.<br>
<pre><code>wget http://arduinotty.googlecode.com/files/arduinotty_v0.2_ubuntu11.10.deb &amp;&amp; sudo dpkg -i arduinotty_v0.2_ubuntu11.10.deb<br>
</code></pre>
This command downloads and installs "Arduino TTY v0.2".</blockquote>

<ul><li><h3>From tarball</h3>
</li></ul><blockquote>You need "mono" and "gtk-sharp-2.0" to run "Arduino TTY v0.2"<br>
and "nant" to compile it, please install these packages.<br>
Then write these commands below into your terminal.<br>
<pre><code>cd ~<br>
wget http://arduinotty.googlecode.com/files/arduinotty_v0.2.tar.gz<br>
tar -xzvf arduinotty_v0.2.tar.gz<br>
cd arduinotty_v0.2<br>
nant -buildfile:build-files/linux.build<br>
sudo nant -buildfile:build-files/linux.build install<br>
</code></pre></blockquote>

<blockquote>If you're encountering a message like the message below, <br>
then please click <a href='Compiling_Problems.md'>here</a>.<br>
<pre><code>The type or namespace name `Gtk' could not be found in the global namespace (are you missing an assembly reference?)<br>
</code></pre>