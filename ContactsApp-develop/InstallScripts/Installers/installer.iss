#define MyAppName "ContactsApp"
#define MyAppVersion "1.0.0"
#define MyAppExeName "ContactsAppUI.exe"
#define MyAppAssocName MyAppName + " File"
#define MyAppAssocExt ".myp"
#define MyAppAssocKey StringChange(MyAppAssocName, " ", "") + MyAppAssocExt
#define AppIconName "Cont.ico"

[Setup]
AppId={{5692675C-AG66-56A3-B5AC-58960A32E4F5}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
DefaultDirName={pf}\{#MyAppName}
OutputBaseFilename=ContactsAppSetup
ChangesAssociations=yes
DisableProgramGroupPage=yes
OutputDir="Installers"
SetupIconFile="..\ContactsAppUI\{#AppIconName}"
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "Release\*.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "Release\*.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\ContactsAppUI\{#AppIconName}"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFileName: "{app}\{#AppIconName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent