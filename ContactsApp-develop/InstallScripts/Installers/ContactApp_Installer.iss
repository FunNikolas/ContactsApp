; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!
 #define MyAppName "ContactApp"
#define MyAppVersion "1.0"
#define MyAppPublisher "Diana Kletsko"
#define MyAppURL "https://githupb/FunNikolas"
#define MyAppExeName "ContactsAppUI.exe"


[Setup]
AppId={{261BE771-07EB-407D-AFDA-837E994BCCD0}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
ChangesAssociations=yes
DisableProgramGroupPage=yes
OutputDir="Installers"
OutputBaseFilename=ContactsApp_Setup
SetupIconFile="..\..\ContactsUI\{#MainForm-icon}"
Compression=lzma
SolidCompression=yes
WizardStyle=modern;

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"


[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "Release\*.dll"; DestDir: "{app}";Flags: ignoreversion 
Source: "Release\*.exe"; DestDir: "{app}"; Flags: ignoreversion


[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}";IconFilename: "{app}\{#MainForm-icon}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent



