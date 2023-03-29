@echo

git add .

@echo off
set /p input= mensagem commit:


git config --global user.email "lukasmedinamanner@gmail.com"
git config --global user.name "Wanddarey"
@echo

git commit -m "%input%"

git push origin main 

@echo off
set /p in=
