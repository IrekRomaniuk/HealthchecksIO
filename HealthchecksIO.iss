; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "HealthchecksIO Service"
#define MyAppVersion "0.1"
#define MyAppPublisher "@IrekRomaniuk"
#define MyAppURL "http://medium.com/@IrekRomaniuk"
#define MyAppExeName "HealthchecksIO.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{7C9A4A4C-BCAD-4124-A5FE-25A424323DDB}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\HealthchecksIO
DisableProgramGroupPage=yes
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputBaseFilename=SetupHealthchecksIO
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\iromaniuk\CSharpProjects\HealthchecksIO\HealthchecksIO\bin\Release\HealthchecksIO.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\iromaniuk\CSharpProjects\HealthchecksIO\HealthchecksIO\bin\Release\HealthchecksIO.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\iromaniuk\CSharpProjects\HealthchecksIO\HealthchecksIO\bin\Release\log4net.dll"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename:"{cmd}"; Parameters:"/c sc.exe create ""{#MyAppName}"" binPath= ""{app}\{#MyAppExeName}"""
Filename:"{cmd}"; Parameters:"/c sc.exe description ""{#MyAppName}"" ""Healtchecks.io Alerts"""

[UninstallRun]
Filename:"{cmd}"; Parameters:"/c sc.exe delete ""{#MyAppName}"""

