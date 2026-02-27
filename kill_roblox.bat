@echo off
chcp 65001 >nul
echo ========================================
echo Roblox Process Terminator
echo ========================================
echo.

echo [*] Searching for Roblox processes...
tasklist | findstr /i "Roblox" >nul
if %errorlevel% equ 0 (
    echo [+] Roblox processes found
    echo [*] Terminating all Roblox processes...
    taskkill /f /im RobloxPlayerBeta.exe 2>nul
    taskkill /f /im RobloxPlayerLauncher.exe 2>nul
    taskkill /f /im RobloxStudioBeta.exe 2>nul
    taskkill /f /im RobloxCrashHandler.exe 2>nul
    timeout /t 2 /nobreak >nul
    echo [+] Done!
) else (
    echo [-] No running Roblox processes found
)

echo.
echo [*] Searching for session unlocker processes...
tasklist | findstr /i "RBXInstance" >nul
if %errorlevel% equ 0 (
    echo [+] Session unlocker found
    echo [*] Terminating...
    taskkill /f /im RBXInstance.exe 2>nul
    timeout /t 1 /nobreak >nul
    echo [+] Done!
) else (
    echo [-] No running session unlocker found
)

echo.
echo ========================================
echo All processes terminated
echo You can now run RBXInstance
echo ========================================
pause
