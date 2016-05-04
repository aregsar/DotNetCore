#Openhouse - a sample project skeleton for ASP.NET CORE 1.0 projects

for installing asp.net core 1.0 rc1 on windows see:

https://docs.asp.net/en/latest/getting-started/installing-on-windows.html

#Instructions for running asp.net core 1.0 rc1 on OSX

If you like to run the project on a Mac OS here is setup instructions that I used on my machine

step 1 - install the .net core 1 rc1 on osx 

first use the installer .pkg download for osx from here:

http://docs.asp.net/en/latest/getting-started/installing-on-mac.html

open a bash terminal

dnvm upgrade -r coreclr

dnvm upgrade -r mono

copy libuv library if it didn’t install properly

cp ~/.dnx/packages/Microsoft.AspNet.Server.Kestrel/1.0.0-rc1-final/runtimes/osx/native/libuv.dylib ~/.dnx/packages/Microsoft.AspNet.Server.Kestrel/1.0.0-rc1-final/lib/dnxcore50/libuv.dylib

set the default runtime

dnvm use 1.0.0-rc1-update1 -r coreclr -arch x64 -p

Install yoeman and aspnet generator

you may require the following step:

deleted symlink  that prevented global yo installation)

rm /usrl/ocal/bin/yo

install yo globally(you need to have node installed)

sudo npm install -g yo

install yo aspnet generator

npm install -g generator-aspnet

step 3 - create and run project

create and navigate to your new project directory

mkdir MyProject && cd MyProject

create a project

yo aspnet

install nugget packages and dependancies

dnu restore

build the app

dnu build

build and run the app

dnx web




