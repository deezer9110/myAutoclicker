# My Autoclicker

![Autoclicker Preview](https://github.com/user-attachments/assets/5e890ddb-ca09-4759-bb71-4c3b86855d68)

## Summary
I built this autoclicker in C# to both learn new concepts in the .NET framework, as well as solve a personal problem of clicker games. It allows for up to ∼70 clicks per second (cps), and features a low-level keyboard hook for easy use. 
I ended up learning a lot about: 
- Making structs for simulated inputs through the Windows API
- Creating low-level keyboard hooks with the use of Hash Sets and Windows API
- Designing a Windows Form App with a suitable UI.
- Threading to keep UI and functions of the autoclicker seperate

## What I used to make it
- Visual Studio 2022 for C# and Windows Forms
- Aid from ChatGPT for learning purposes
- [Stephen Toub's Post on LL Keyboard Hooks](https://learn.microsoft.com/en-us/archive/blogs/toub/low-level-keyboard-hook-in-c), where a slightly modified version of his class is in the code, which i remade myself in GlobalKeyBoardHook.cs
- Stack Overflow threads
- [Windows Learning Site, particularly for the SendInput function and its links](https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendinput)  
- P/Invoke commands from [pinvoke.net](https://pinvoke.net)


## How to Download
Feel free to clone with the url
```
git clone https://github.com/deezer9110/myAutoclicker.git
```
`Ctrl+Shift+B` to build it in VS2022 and it can be run from the `.exe` file.

## How to Use
- **START** -> Begins clicking at the desired CPS (defaulted to 10)
- **STOP** -> Stops clicking regardless of what's happening
- **UPDATE** -> Stops clicking and sets new parameters for CPS and how long you'd like it to click for (NOTE: If a clicking timer is set, it will disable the keyboard hook temporarily to prevent conflicts of autoclicker instance)
- **ANTI-AFK** -> Simulates a random press of 'A' and then 'D' key, however, it may not function on some games depending on their input system, but does work for standard text
- **SET CPS txt** -> Input a desired integer CPS
- **SET CLICKING TIMER txt** -> Input a desired integer amount of time in seconds
- **LL KEYBOARD HOOK** = `Ctrl + Shift + A` -> Will toggle the autoclicker system wide, unhooks when app is closed, and is disabled while a clicking timer is active

### Limitations
- CPS limited to ∼70 CPS due to C#'s Timer, with a rough minimum interval of 15.6ms, but I kept it coded with this so it's not overly intensive
- Anti AFK toggle may not work in some games as previously stated

# License
This project is under the **GNU General Public License**, see [License](LICENSE)
