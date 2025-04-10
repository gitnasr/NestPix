
<img width="64" height="64" src="https://github.com/user-attachments/assets/e20e9f75-766d-44b5-83da-c0949ad587b2"/>

# NestPix 

[![GitHub release (latest by date)](https://img.shields.io/github/v/release/gitnasr/NestPix)](https://github.com/gitnasr/NestPix/releases/latest)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT) 
[![GitHub stars](https://img.shields.io/github/stars/gitnasr/NestPix?style=social)](https://github.com/gitnasr/NestPix/stargazers)
[![GitHub forks](https://img.shields.io/github/forks/gitnasr/NestPix?style=social)](https://github.com/gitnasr/NestPix/network/members)
[![GitHub issues](https://img.shields.io/github/issues/gitnasr/NestPix)](https://github.com/gitnasr/NestPix/issues)
[![Language](https://img.shields.io/github/languages/top/gitnasr/NestPix)](https://github.com/gitnasr/NestPix)

Tired of manually sorting through endless folders of images? 😩 NestPix is here to help! ✨ It's a Windows desktop application built with .NET 8 and WinForms, designed for rapid image viewing and sorting across nested directories. Quickly decide which images to keep and which to discard using simple keyboard shortcuts.

## 🌟 Features

*   **📂 Recursive Folder Scanning:** Scans a root folder and all its subdirectories for images (`.jpg`, `.jpeg`, `.png`, `.bmp`, `.webp`).
*   **🖼️ Efficient Image Viewing:** Quickly loads and displays images one by one.
*   **➡️⬅️ Keyboard Navigation:** Use configurable keys (**Default: A/D**) to move between images within and across folders.
*   **🗑️ Quick Deletion/Sorting:** Mark images for deletion (**Default: W**). Marked images are moved to a dedicated `DeletedContent` folder, not permanently lost immediately, allowing for recovery.
*   **💾 Session Persistence:** Remembers which images you've already seen (skipped/deleted) in a specific root folder, allowing you to resume sorting later without reviewing the same images again.
*   **👁️ Draggable Preview:** Shows a small, draggable preview overlay of the *next* image on the current one (toggle by clicking the main image).
*   **⌨️ Customizable Shortcuts:** Easily change the default keybindings for Next, Previous, and Delete actions via the settings menu.
*   **🚶‍♂️ Idle Detection & Auto-Save:** Automatically saves progress (moves marked files) if the application detects user inactivity for a set period (default: 10 minutes), preventing loss of work.
*   **🔄 Update Checker:** Notifies users about new releases available on GitHub upon startup.



## 🛠️ Technology Stack

*   **Language:** C#
*   **Framework:** .NET 8
*   **UI:** Windows Forms (WinForms)
*   **Database:** SQLite (via Entity Framework Core 9) - Stores session data, cached image status, and shortcuts.
*   **Image Loading:** SixLabors.ImageSharp - Robust image format support.
*   **API Interaction:** Newtonsoft.Json - Used for parsing GitHub API responses (Update Check).

## 🚀 Installation & Setup

**Option 1: Pre-built Release (Recommended)**

1.  Go to the [**Releases**](https://github.com/gitnasr/NestPix/releases/latest) page.
2.  Download the latest `.zip` file from the Assets section.
3.  Extract the zip file and run `NestPix.exe`.

**Option 2: Build from Source**

1.  **Prerequisites:**
    *   [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
    *   [Git](https://git-scm.com/downloads)
2.  **Clone the repository:**
    ```bash
    git clone https://github.com/gitnasr/NestPix.git
    cd NestPix
    ```
3.  **Build the project:**
    *   Using .NET CLI: `dotnet build --configuration Release`
    *   Or open `NestPix.sln` in Visual Studio 2022 (or later) and build the solution (select Release configuration).
4.  **Run the application:**
    *   Navigate to the output directory (e.g., `NestPix/bin/Release/net8.0-windows/`)
    *   Execute `NestPix.exe`.

## 📖 Usage

1.  Launch `NestPix.exe`.
2.  On the **Start Screen**, paste the full path to the root folder containing the images you want to sort into the "Folder Path" text box.
3.  Click the **"Go"** button.
4.  The application will scan the specified folder and its subfolders for images. A status message will indicate progress. Already processed images from previous sessions in this root folder will be skipped.
5.  The **Viewer Screen** will open, displaying the first image found.
6.  **Navigate and Sort:**
    *   Press **`D`** (Default) to go to the **Next** image (marks current as skipped).
    *   Press **`A`** (Default) to go to the **Previous** image (if available).
    *   Press **`W`** (Default) to **Mark the current image for Deletion**. The counter at the bottom and the "Save Changes" button will update.
7.  **Preview:** Click the main image area to toggle the draggable preview overlay showing the next image. Double-click the overlay to hide it.
8.  **Saving Changes:**
    *   Click the **"Save Changes"** button (enabled when images are marked for deletion) to move all marked images to the `DeletedContent` folder. A confirmation prompt will appear.
    *   Alternatively, if you are idle for 10 minutes and have images marked, the application will automatically save the changes.
    *   Changes are also saved automatically when closing the Viewer Screen or the application.
9.  **Accessing Deleted Files:** Use the **"Open Delete Folder"** option from the Start Screen's menu (or the button on the Viewer Screen) to open the `DeletedContent` folder in Windows Explorer. This folder is located in the same directory as `NestPix.exe`.
10. **Customizing Shortcuts:** Use the **"Edit Keybindg"** menu option on the Start Screen to open the shortcut editor. Click a button (Next, Back, Delete) and then press the desired key to assign it. Changes are saved when the editor window is closed.

## 🧠 Key Algorithms & Logic

Here's a brief overview of how some core parts of NestPix work:

*   **🖼️ Image Discovery & Filtering (`FilesService`)**
    *   Uses `Directory.EnumerateFiles` with `EnumerationOptions` to efficiently traverse the specified directory tree, skipping hidden/system files.
    *   Filters discovered files based on a list of common image extensions (`.jpg`, `.png`, etc.).
    *   Groups the valid image paths into a `Dictionary<string, List<string>>` where the key is the directory path.
    *   Sorts the dictionary keys (directory paths) and the list of image paths within each directory alphabetically for consistent ordering.
    *   **Optimization:** Before starting the viewing session, it queries the SQLite database (`CacheRepo.GetExistingCacheByParentFolder`) for any images within the *target root folder* that were marked as `IsSkipped` or `IsDeleted` in *previous sessions*. It then removes these already-processed images from the list for the current session, preventing redundant sorting.
    *   Finally, it creates a `Session` record in the database (`SessionRepo.CreateSession`) to track the current sorting activity.

*   **🧭 Navigation Logic (`NavigationService`)**
    *   Manages the state of image viewing by keeping track of the current directory index (`CurrentDirIndex`) and the current image index within that directory (`CurrentImageIndex`) relative to the filtered `ImageFiles` dictionary.
    *   `GetNext()`: Increments `CurrentImageIndex`. If it goes past the end of the current directory's list, it increments `CurrentDirIndex`, resets `CurrentImageIndex` to `0`, and loads the next directory's image list. It determines the path for the small preview overlay (`PreviewImage`) which shows the image *after* the one currently returned. Returns a `Pix` object containing current and preview image details, or an invalid `Pix` if the end is reached.
    *   `GetPrevious()`: Decrements `CurrentImageIndex`. If it goes below `0`, it decrements `CurrentDirIndex`, loads the previous directory's image list, and sets `CurrentImageIndex` to the *last* index of that list. Handles the start-of-list boundary case.
    *   Relies on the `Dir` helper class to simplify checking for the existence of next/previous directories.

*   **💾 Caching & Deletion (`NavigationService`, `CacheRepo`, `SessionRepo`)**
    *   When the user navigates (Next) or marks for deletion (Delete), `NavigationService.AddToCache()` is invoked.
    *   This method interacts with `CacheRepo` to record the action in the database for the *current session*.
    *   It checks if a `Cache` entry exists for the specific image *in the current session*. If not, it creates one, linking it to the `CurrentSession.id` and setting `IsSkipped = true` (for Next) or `IsDeleted = true` (for Delete). If an entry exists (e.g., user navigated back and forth), it updates the existing entry's `IsSkipped`/`IsDeleted` flags.
    *   `NavigationService.DeleteAll()` is triggered by the "Save Changes" button, idle timeout, or application close.
        *   It calls `CacheRepo.GetMarkedAsDeletedBySession()` to fetch all `Cache` entries marked `IsDeleted` for the current session.
        *   It iterates through these entries and uses `File.Move` to move the actual image file from its original location to the `ConfigService.DeleteFolderPath` (`DeletedContent` subfolder).
        *   It also removes the processed image path from the in-memory `ImageFiles` dictionary.

*   **⏳ Idle Detection (`IdleHook`, `ViewerScreen`, `ConfigService`)**
    *   `IdleHook`: Uses P/Invoke (`user32.dll`, `GetLastInputInfo`) to query the Windows API for the system-wide last user input time. It calculates the idle duration.
    *   `ViewerScreen`: Contains a `System.Windows.Forms.Timer` (`IdleTimer`) that periodically calls `IdleHook.GetIdleTime()`.
    *   If the returned idle time exceeds the threshold defined in `ConfigService.IdleTimeInSeconds` (default: 10 minutes) *and* there are images marked for deletion (`MarkedAsDeletedCount > 0`), it automatically calls `HandleDelete()` (which in turn calls `NavigationService.DeleteAll()`) to save the user's progress.

## ⚙️ Configuration

*   **Shortcuts:** Keyboard shortcuts for Next, Previous, and Delete can be customized via the "Edit Keybindg" menu option on the Start Screen. These settings are stored in the `app.db` SQLite database file located alongside the executable.
*   **Deleted Files Location:** Images marked for deletion are moved (not permanently deleted) to a subfolder named `DeletedContent` within the application's directory.

## 🤝 Contributing

Contributions are welcome! If you have suggestions for improvements or encounter any bugs, please feel free to:

1.  Open an [**Issue**](https://github.com/gitnasr/NestPix/issues) to discuss the change or report the bug.
2.  Fork the repository, make your changes, and submit a [**Pull Request**](https://github.com/gitnasr/NestPix/pulls).

