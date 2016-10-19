echo Please copy the batch file to the application's root directory,
echo then execute directly.

pause
pause

echo delete the exsiting directories.

rmdir /s /q  Components
rmdir /s /q  DevExpress
rmdir /s /q  Smth

echo create the directories again.

md Components
md DevExpress
md Smth

echo move dll to directory

move DevExpress.*.dll ./DevExpress
move Nzl.Smth*.dll ./Smth
move Nzl.*.dll ./Components

echo All is done!
pause