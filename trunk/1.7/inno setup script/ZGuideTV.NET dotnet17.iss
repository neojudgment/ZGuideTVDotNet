;ZGuideTV.NET script install copyright by Pascal Hubert aka Néo (ZGuideTV Team) 2005-2016
; ---------------------------------------------

[_ISTool]
EnableISX=true

#define use_msi45
#define use_dotnetfx46

#define BaseFolder "..\bin\x86\Release"
#define AppName "ZGuideTV.NET"
#define MyAppName "ZGuideTV.NET"
#define ExeName BaseFolder+"\ZGuideTVDotNet.exe"
#define AppVersionNo GetFileVersion(ExeName)
#define AppMajorVersionIdx Pos(".", AppVersionNo)
#define AppMinorVersionTemp Copy(AppVersionNo, AppMajorVersionIdx +1)
#define AppMajorVersionNo Copy(AppVersionNo, 1, AppMajorVersionIdx -1)
#define AppMinorVersionNo Copy(AppMinorVersionTemp, 1, Pos(".", AppMinorVersionTemp)-1)
#define MyAppPublisher "ZGuideTV Team"
#define MyAppURL "http://zguidetv.codeplex.com/"
#define MyAppSupportURL "http://www.zguidetv.net/"
#define MyAppExeName "ZGuideTVDotNet.exe"
#define MyAppUrlNameEn "ZGuideTVEn.url"
#define MyAppUrlNameFr "ZGuideTVFr.url"
#define MyAppUrlSupport "xmltvfr.url"

#define MyAppUrlQuickStartEn "ZGuideTVQuickStartEn.url"
#define MyAppUrlQuickStartFr "ZGuideTVQuickStartFr.url"

#define ISSI_BeveledLabel "ZGuideTV.NET - © 2004 - 2017 ZGuideTV Team"
#define ISSI_UnZip1 "logos\logos.zip"
#define ISSI_UnZipDir1 "{commonappdata}\ZGuideTVDotNet\Logos"

#define ISSI_IncludePath "C:\ISSI"
#include ISSI_IncludePath+"\_issi.isi"

[Setup]
; SignTool=signtool
; Signature du code
AppVerName={#MyAppName} 1.7 beta 5
; {#AppMajorVersionNo}.{#AppMinorVersionNo}
AppVersion={#AppVersionNo}
; nom de l'application (déclaré ci-dessus)
AppName={#AppName}
; site de ZGuideTV (déclaré ci-dessus)
AppPublisher={#MyAppPublisher}
; copyright (déclaré ci-dessus)
AppPublisherURL={#MyAppURL}
; site du support de ZGuideTV (déclaré ci-dessus)
AppSupportURL={#MyAppSupportURL}
; site de mise Ã  jour ZGuideTV (déclaré ci-dessus)
AppUpdatesURL={#MyAppURL}
; répertoire d'installation (par défaut : C:\Program Files\ZGuideTVDotNet)
DefaultDirName={pf}\ZGuideTVDotNet
; groupe d'installation (par défautt : \ZGuideTV.NET)
DefaultGroupName={#MyAppName}
; priviléges des utilisateurs (admin/utilsateur etc..)
PrivilegesRequired=admin
; version minimum de Windows supporté
MinVersion=0,6.0sp2
; détection auto de la langue
; LanguageDetectionMethod=uilanguage
; affiche la sélection de la langue
ShowLanguageDialog=yes
; logo de gauche durant l'install
WizardImageFile=images\sysopsparadise1.bmp
; logo au dessus Ã  droite durant l'install
WizardSmallImageFile=images\logo3.bmp
; répertoire de sortie le l'exécutable (installeur) durant la compilation
OutputDir=Output
; icone de l'exécutable (installeur)
SetupIconFile=Resources\Setup.ico
; avertir si le répertoire d'installation existe déjà
DirExistsWarning=no
; avertir si le répertoire d'installation n'existe pas
EnableDirDoesntExistWarning=false
; icone utilisÃ© pour la déinstallation
; fenÃªtre Ã  afficher avant installation (ici la license MS-RL)
InfoBeforeFile=licence\license.rtf
; activer ou désactiver la fenêtre "attention vous étes sur le point d'installer ZGuideTV...)
DisableStartupPrompt=true
; les icones sont déclarés ci-dessus donc "true"
AllowNoIcons=true
; Copyright
AppCopyright=ZGuideTV Team
; nom de sortie du fichier
OutputBaseFilename= ZGuideTVDotNet_17_beta_5
;{#AppMajorVersionNo}
; {#AppMinorVersionNo}
; on affiche toutes les langues
ShowUndisplayableLanguages=true
; l'identification unique du programme
; AppID={{706C8704-2B01-4269-BD68-A3A48CF4D53F}
; version de l'intalleur actuel pour comparer avec un futur installeur
; On utilise si possible l'ancien répertoire
UsePreviousAppDir=true
; On utilise si possible le même groupe
UsePreviousGroup=true
; On utilise si possible la même langue
UsePreviousLanguage=Yes
; type d'installation
UsePreviousSetupType=false
; type de tâche
UsePreviousTasks=false
; méthode de compression
Compression=lzma2/Max
; solid compression
SolidCompression=true
; compression interne
InternalCompressLevel=Normal
; icone de désinstallation (panneau de configuration)
VersionInfoVersion={#AppVersionNo}
; nom de la société
VersionInfoCompany=ZGuideTV Team
; description du soft
VersionInfoDescription=ZGuideTV.NET
; copyright
VersionInfoCopyright=Copyright © 2004 - 2017
; nom du soft
VersionInfoProductName=ZGuideTV.NET
; numéro de version
VersionInfoProductVersion={#AppVersionNo}
; icone de désinstallation
UninstallDisplayIcon={app}\ZGuideTVDotNet.exe
; Mutex
AppMutex=ZGUIDETV_MUTEX
; on autorise l'installation en x64
ArchitecturesInstallIn64BitMode=x64
; Création fichier log
SetupLogging=yes
; si c'est une mise à jour on évite de demander le répertoire d'installation et la création du groupe
DisableDirPage=auto
DisableProgramGroupPage=auto
ShowTasksTreeLines=True

[Languages]
; les langues utilisées durant l'installation
Name: en; MessagesFile: languages\English.isl
Name: fr; MessagesFile: languages\French.isl

[Tasks]
; propose de créer un icone sur le bureau durant l'installation (par défaut : non sélectionné)
Name: desktopicon; Description: {cm:CreateDesktopIcon}; GroupDescription: {cm:AdditionalIcons}
; propose de créer un icone dans la barre de lancement rapide durant l'installation (par défaut : non sélectionné)
Name: quicklaunchicon; Description: {cm:CreateQuickLaunchIcon}; GroupDescription: {cm:AdditionalIcons}; Flags: unchecked

[Files]
Source: scripts\isxdl\isxdl.dll; Flags: dontcopy
Source: scripts\isxdl\english.ini; Flags: dontcopy
Source: scripts\isxdl\french.ini; Flags: dontcopy

;Source: C:\Program Files (x86)\Windows Kits\10\bin\10.0.15063.0\x86\certmgr.exe; DestDir: {app}; Flags: deleteafterinstall
;Source: ..\bin\Release\AscertiaRootCA.der; DestDir: {app}; Flags: deleteafterinstall

Source: ..\bin\Release\ZGuideTVDotNet.exe; DestDir: {app}; BeforeInstall: AskRestorePoint; Flags: ignoreversion
Source: bin\Windows7.DesktopIntegration.Registration.exe; DestDir: {app}; Flags: ignoreversion
Source: Resources\ZGuideTVDotNet.url.set; Destdir: {userappdata}\ZGuideTVDotNet\Url; Flags: onlyifdoesntexist uninsneveruninstall
Source: Resources\ZGuideTVDotNet.marked.set; Destdir: {userappdata}\ZGuideTVDotNet\Marked; Flags: onlyifdoesntexist uninsneveruninstall
Source: Resources\xmltv.dtd; DestDir: {app}; Flags: ignoreversion
;Source: bin\ZGuideTVDotNet.exe.config; DestDir: {app}
Source: ..\changelog\Changelogfra.txt; DestDir: {app}; Flags: ignoreversion
Source: ..\changelog\Changelogeng.txt; DestDir: {app}; Flags: ignoreversion
Source: licence\licence.rtf; DestDir: {app}
Source: licence\license.rtf; DestDir: {app}
source: ..\bin\Release\RemoteControl\iMON\ZGuideTVDotNet.imo; DestDir: {app}\RemoteControl\iMON; Flags: ignoreversion
source: ..\bin\Release\languages\English.lng; DestDir: {app}\languages; Flags: ignoreversion
source: ..\bin\Release\languages\Français.lng; DestDir: {app}\languages; Flags: ignoreversion
Source: dll32\sqlite3.dll; DestDir: {app}\dll32; Check: not Is64BitInstallMode; Flags: ignoreversion
Source: dll64\sqlite3.dll; DestDir: {app}\dll64; Check: Is64BitInstallMode; Flags: ignoreversion
Source: ..\References\TvdbLib.dll; DestDir: {app}; Flags: ignoreversion
Source: ..\References\Microsoft.WindowsAPICodePack.dll; DestDir: {app}; Flags: ignoreversion
Source: ..\References\Microsoft.WindowsAPICodePack.Shell.dll; DestDir: {app}; Flags: ignoreversion
Source: ..\References\Windows7.DesktopIntegration.dll; DestDir: {app}; Flags: ignoreversion
Source: ..\References\VistaBridgeLibrary.dll; DestDir: {app}; Flags: ignoreversion
Source: ..\References\NAudio.dll; Destdir: {app}; Flags: ignoreversion
Source: ..\bin\Release\ZGuideTVDotNet.Resources.dll; DestDir: {app}; AfterInstall: AddFirewallException

[Icons]
; création des icones suivant la langue sélectionnée
Name: {group}\{#MyAppName}; Filename: {app}\{#MyAppExeName}; WorkingDir: {app}; IconFilename: {app}\ZGuideTVDotNet.exe; IconIndex: 0

Name: {group}\ZGuideTV.NET - Mode déconnecté; Filename: {app}\ZGuideTVDotNet.exe; Parameters: "/offline"; WorkingDir: {app}; Languages: fr; IconFilename: {app}\ZGuideTVDotNet.exe; IconIndex: 0
Name: {group}\URL - ZGuideTV.NET Site Officiel; Filename: {app}\{#MyAppUrlNameFr}; Languages: fr; IconFilename: {pf}\Internet Explorer\iexplore.exe
Name: {group}\URL - ZGuideTV.NET Forum d'Aide; Filename: {app}\{#MyAPPUrlSupport}; Languages: fr; IconFilename: {pf}\Internet Explorer\iexplore.exe
Name: {group}\ZGuideTV.NET - Notes de révision; Filename: {app}\changelogfra.txt; WorkingDir: {app}; Languages: fr; IconFilename: {win}\system32\notepad.exe
Name: {group}\ZGuideTV.NET - Licence; Filename: {app}\licence.rtf; WorkingDir: {app}; Languages: fr
Name: {group}\URL - ZGuideTV.NET Démarrage rapide; Filename: {app}\{#MyAppUrlQuickStartFr}; Languages: fr; IconFilename: {pf}\Internet Explorer\iexplore.exe
Name: {group}\ZGuideTV.NET - Désinstallation; Filename: {uninstallexe}; Languages: fr

Name: {group}\ZGuideTV.NET - Offline Mode; Filename: {app}\ZGuideTVDotNet.exe; Parameters: "/offline"; WorkingDir: {app}; Languages: en; IconFilename: {app}\ZGuideTVDotNet.exe; IconIndex: 0
Name: {group}\URL - ZGuideTV.NET Official Site; Filename: {app}\{#MyAppUrlNameEn}; Languages: en; IconFilename: {pf}\Internet Explorer\iexplore.exe
Name: {group}\URL - ZGuideTV.NET Help Forum; Filename: {app}\{#MyAPPUrlSupport}; Languages: en; IconFilename: {pf}\Internet Explorer\iexplore.exe
Name: {group}\ZGuideTV.NET - Release notes; Filename: {app}\changelogeng.txt; WorkingDir: {app}; Languages: en; IconFilename: {win}\system32\notepad.exe
Name: {group}\ZGuideTV.NET - License; Filename: {app}\license.rtf; WorkingDir: {app}; Languages: en
Name: {group}\URL - ZGuideTV.NET Quick Start; Filename: {app}\{#MyAppUrlQuickStartEn}; Languages: en; IconFilename: {pf}\Internet Explorer\iexplore.exe
Name: {group}\ZGuideTV.NET - Uninstall; Filename: {uninstallexe}; Languages: en

Name: {userdesktop}\{#MyAppName}; Filename: {app}\{#MyAppExeName}; WorkingDir: {app}; Tasks: desktopicon
Name: {userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}; Filename: {app}\{#MyAppExeName}; WorkingDir: {app}; Tasks: quicklaunchicon

[Registry]
; création des clés dans la base de registre
Root: HKLM; Subkey: "Software\ZGuideTV Team"; Flags: uninsdeletekey
Root: HKLM; Subkey: "Software\ZGuideTV Team\ZGuideTV.NET"; Flags: uninsdeletekey
Root: HKLM; Subkey: "Software\ZGuideTV Team\ZGuideTV.NET\Settings"; ValueType: string; ValueName: "InstallPath"; ValueData: "{app}"

[Dirs]
; création des sous répertoires \logos  \languages \RemoteControl
Name: {commonappdata}\ZGuideTVDotNet\Logos; Flags: uninsalwaysuninstall
Name: {userappdata}\ZGuideTVDotNet\Log; Flags: uninsalwaysuninstall
Name: {userappdata}\ZGuideTVDotNet\Marked; Flags: uninsalwaysuninstall
Name: {userappdata}\ZGuideTVDotNet\Channels; Flags: uninsalwaysuninstall
Name: {userappdata}\ZGuideTVDotNet\Url; Flags: uninsalwaysuninstall
Name: {userappdata}\ZGuideTVDotNet\Database; Flags: uninsalwaysuninstall
Name: {userappdata}\ZGuideTVDotNet\AutoComplete; Flags: uninsalwaysuninstall
Name: {userdocs}\ZGuideTVDotNet; Flags: uninsalwaysuninstall
Name: {userdocs}\ZGuideTVDotNet\Temp; Flags: uninsalwaysuninstall

Name: {app}; Flags: uninsalwaysuninstall
Name: {app}\languages; Flags: uninsalwaysuninstall
Name: {app}\RemoteControl; Flags: uninsalwaysuninstall
Name: {app}\profiles; Flags: uninsalwaysuninstall
Name: {app}\dll32; Flags: uninsalwaysuninstall; Check: not Is64BitInstallMode
Name: {app}\dll64; Flags: uninsalwaysuninstall; Check: Is64BitInstallMode


[UninstallDelete]
; durant la dé-installation on efface les fichiers et répertoires{#MyAppName}
Type: filesandordirs; Name: {app}
; Type: filesandordirs; Name: {userappdata}\ZGuideTVDotNet
; Type: filesandordirs; Name: {localappdata}\ZGuideTV_Team
Type: filesandordirs; Name: {commonappdata}\ZGuideTVDotNet

[InstallDelete]
; durant l'installation on efface les fichiers et répertoires{#MyAppName}
Type: files; Name: {app}\ZGuideTVDotNet.Description.dll
Type: files; Name: {app}\ZGuideTVDotNet.Render.dll
Type: files; Name: {app}\index-fr.chm
Type: files; Name: {app}\index-fr.chm
Type: files; Name: {app}\7z.exe
Type: files; Name: {app}\7z.dll
Type: files; Name: {app}\ZGuideTVDotNet.PluginDefinitions.dll
Type: files; Name: {app}\NAudio.WindowsMediaFormat.dll
Type: files; Name: {app}\sqlite3.dll
Type: files; Name: {app}\ZGuideTVDotNet.url.set
Type: filesandordirs; Name: {app}\Plugins
Type: filesandordirs; Name: {app}\Media
Type: filesandordirs; Name: {pf32}\ZGuideTVDotNet; Check: Is64BitInstallMode

[CustomMessages]
en.dotnetmissing=ZGuideTV.NET requires the .NET Framework v4.5.2. Please download and install the .NET Framework v4.5.2 and run this setup again!
fr.dotnetmissing=ZGuideTV.NET requiert le Framework .NET v4.5.2. Téléchargez et installez le Framework .NET v4.5.2 et lancez à nouveau cet assistant d'installation!

en.deleteall=To avoid compatibility problems if an older release is currently installed this one will be deleted!
fr.deleteall=Afin d'éviter des problémes de compatibilitè si une ancienne version est actuellement installée celle-ci sera supprimée!

en.restorepoint=Do you want to create a restore point? (Recommended) If you select yes, the creation will take a few moments.
fr.restorepoint=Voulez-vous créer un point de restauration ? (Recommandé) Si vous sélectionnez oui, la création de celui-ci prendra quelques instants.

en.restorepointsuccessful=Restore Point successfully created!
fr.restorepointsuccessful=Point de restauration créé avec succès!

en.restorepointprogress=Creating a restore point in progress...
fr.restorepointprogress=Création d'un point de restauration en cours...

en.restorepointunsuccessful=System Restore was unable to create a restore point. The service cannot be started or are disabled!
fr.restorepointunsuccessful=La restauration du systéme n'a pas été en mesure de créer un point de restauration. Le service ne peut-être démarré ou est désactivé !

en.restorepointunsuccessful2=This error will not affect the ZGuideTV.NET efficiency.
fr.restorepointunsuccessful2=Cette erreur n'aura aucune incidence sur le bon fonctionnement de ZGuideTV.NET.

en.restorepointunsuccessful3=Press OK to continue or Cancel to exit...
fr.restorepointunsuccessful3=Appuyez sur OK pour continuer ou sur Annuler pour quitter...

en.AddFirewall=Do you want to add an exception in Windows Firewall? (Recommended)
fr.AddFirewall=Voulez-vous ajouter une exception dans le Pare-feu Windows ? (Recommandé)

en.ngen=Optimising ZGuideTV.NET performance. Please wait...
fr.ngen=Optimisation des performances de ZGuideTV.NET. Veuillez patienter...

en.InstallFor=Install for:
fr.InstallFor=Installer pour :

en.AllUsers=All Users
fr.AllUsers=Tous Utilisateurs

en.CurrentUser=Current User only
fr.CurrentUser=Utilisateur Actuel Uniquement

en.backup=Do you want to delete the backup directory, database, url file and settings?
fr.backup=Voulez-vous effacer le répertoire de sauvegarde, la base de données, et les paramètres ?

win_sp_title=Windows %1 Service Pack %2

[Run]

;Filename: {app}\CertMgr.exe; Parameters: "-add -all -c AscertiaRootCA.der -s -r localMachine root"; Flags: waituntilterminated runhidden;

;x64 fr
Filename: "{dotnet4064}\ngen.exe"; Parameters: "install ""{app}\ZGuideTVDotNet.exe"""; WorkingDir: {app}; Languages: fr;Flags: runhidden; StatusMsg: Optimisation des performances. Veuillez patienter...; Check: IsWin64

;x64 en
Filename: "{dotnet4064}\ngen.exe"; Parameters: "install ""{app}\ZGuideTVDotNet.exe"""; WorkingDir: {app}; Languages: en;Flags: runhidden; StatusMsg: Optimizing performance. Please wait...; Check: IsWin64
                                                 
;x32 fr
Filename: "{dotnet4032}\ngen.exe"; Parameters: "install ""{app}\ZGuideTVDotNet.exe"""; WorkingDir: {app}; Languages: fr;Flags: runhidden; StatusMsg: Optimisation des performances. Veuillez patienter...; Check: not IsWin64

;x32 en
Filename: "{dotnet4032}\ngen.exe"; Parameters: "install ""{app}\ZGuideTVDotNet.exe"""; WorkingDir: {app}; Languages: en;Flags: runhidden; StatusMsg: Optimizing performance. Please wait...; Check: not IsWin64

Filename: "{app}\ZGuideTVDotNet.exe"; Description: Démarrer ZGuideTV.NET; Languages: fr; Flags: postinstall nowait shellexec
Filename: "{app}\ZGuideTVDotNet.exe"; Description: Run ZGuideTV.NET; Languages: en; Flags: postinstall nowait shellexec

#include "scripts\products.iss"

#include "scripts\products\stringversion.iss"
#include "scripts\products\winversion.iss"
#include "scripts\products\fileversion.iss"
#include "scripts\products\dotnetfxversion.iss"

#ifdef use_iis
#include "scripts\products\iis.iss"
#endif

#ifdef use_kb835732
#include "scripts\products\kb835732.iss"
#endif

#ifdef use_msi20
#include "scripts\products\msi20.iss"
#endif
#ifdef use_msi31
#include "scripts\products\msi31.iss"
#endif
#ifdef use_msi45
#include "scripts\products\msi45.iss"
#endif

#ifdef use_ie6
#include "scripts\products\ie6.iss"
#endif

#ifdef use_dotnetfx11
#include "scripts\products\dotnetfx11.iss"
#include "scripts\products\dotnetfx11sp1.iss"
#ifdef use_dotnetfx11lp
#include "scripts\products\dotnetfx11lp.iss"
#endif
#endif

#ifdef use_dotnetfx20
#include "scripts\products\dotnetfx20.iss"
#include "scripts\products\dotnetfx20sp1.iss"
#include "scripts\products\dotnetfx20sp2.iss"
#ifdef use_dotnetfx20lp
#include "scripts\products\dotnetfx20lp.iss"
#include "scripts\products\dotnetfx20sp1lp.iss"
#include "scripts\products\dotnetfx20sp2lp.iss"
#endif
#endif

#ifdef use_dotnetfx35
//#include "scripts\products\dotnetfx35.iss"
#include "scripts\products\dotnetfx35sp1.iss"
#ifdef use_dotnetfx35lp
//#include "scripts\products\dotnetfx35lp.iss"
#include "scripts\products\dotnetfx35sp1lp.iss"
#endif
#endif

#ifdef use_dotnetfx40
#include "scripts\products\dotnetfx40client.iss"
#include "scripts\products\dotnetfx40full.iss"
#endif

#ifdef use_dotnetfx46
#include "scripts\products\dotnetfx46.iss"
#endif

#ifdef use_wic
#include "scripts\products\wic.iss"
#endif

#ifdef use_vc2010
#include "scripts\products\vcredist2010.iss"
#endif

#ifdef use_mdac28
#include "scripts\products\mdac28.iss"
#endif
#ifdef use_jet4sp8
#include "scripts\products\jet4sp8.iss"
#endif

#ifdef use_sqlcompact35sp2
#include "scripts\products\sqlcompact35sp2.iss"
#endif

#ifdef use_sql2005express
#include "scripts\products\sql2005express.iss"
#endif
#ifdef use_sql2008express
#include "scripts\products\sql2008express.iss"
#endif

[UninstallRun]

;x64 fr
Filename: "{dotnet4064}\ngen.exe"; Parameters: "uninstall ""{app}\ZGuideTVDotNet.exe"""; WorkingDir: {app}; Languages: fr;Flags: runhidden; StatusMsg: Désinstallation de ZGuideTV.NET et dépendances...; Check: IsWin64

;x64 en
Filename: "{dotnet4064}\ngen.exe"; Parameters: "uninstall ""{app}\ZGuideTVDotNet.exe"""; WorkingDir: {app}; Languages: en;Flags: runhidden; StatusMsg: Uninstall ZGuideTV.NET and dependencies...; Check: IsWin64

;x32 fr
Filename: "{dotnet4032}\ngen.exe"; Parameters: "uninstall ""{app}\ZGuideTVDotNet.exe"""; WorkingDir: {app}; Languages: fr;Flags: runhidden; StatusMsg: Désinstallation de ZGuideTV.NET et dépendances...; Check: not IsWin64

;x32 en
Filename: "{dotnet4032}\ngen.exe"; Parameters: "uninstall ""{app}\ZGuideTVDotNet.exe"""; WorkingDir: {app}; Languages: en;Flags: runhidden; StatusMsg: Uninstall ZGuideTV.NET and dependencies...; Check: not IsWin64

[ThirdParty]
CompileLogMethod=append

[Code]

 //Propose de créer un point de restauration sous vista/7/8/10
const
 // Types du point de restauration
 APPLICATION_INSTALL = 0;
 APPLICATION_UNINSTALL = 1;
 DEVICE_DRIVER_INSTALL = 10;
 MODIFY_SETTINGS = 12;
 CANCELLED_OPERATION = 13;

 // Types d'événement
 BEGIN_SYSTEM_CHANGE = 100;
 END_SYSTEM_CHANGE  = 101;
 BEGIN_NESTED_SYSTEM_CHANGE = 102;
 END_NESTED_SYSTEM_CHANGE = 103;

function createRestorePoint(RestoreName : String; RestorePointType,
EventType : Integer): boolean;
var
  ScriptControl,
  sr: Variant;
begin
  ScriptControl := CreateOleObject('ScriptControl');
  ScriptControl.Language := 'VBScript';
  sr :=
ScriptControl.Eval('getobject("winmgmts:\\.\root\default:Systemrestore")');
  Result := (sr.CreateRestorePoint(RestoreName, RestorePointType, EventType) = 0);
end;

procedure AskRestorePoint();
var
  StatusText: string;
  j: Integer;
  isSilent: Boolean;
  begin
  isSilent := False;
  for j := 1 to ParamCount do
    if CompareText(ParamStr(j), '/silent') = 0 then

    begin
    isSilent := True;
     Break;
    end;

if GetWindowsVersion >= $05010000 then
  begin

  if not isSilent then
if msgbox(ExpandConstant('{cm:restorePoint}'), mbconfirmation, mb_yesno) = idyes then
 
begin

StatusText := WizardForm.StatusLabel.Caption;
WizardForm.StatusLabel.Caption := CustomMessage('restorepointprogress');
WizardForm.ProgressGauge.Style := npbstMarquee;

    try
if createRestorePoint('ZGuideTV.NET',
APPLICATION_INSTALL,
BEGIN_SYSTEM_CHANGE) then

   MsgBox(ExpandConstant('{cm:restorepointsuccessful}'), mbInformation, MB_OK) else
   MsgBox(ExpandConstant('{cm:restorepointunsuccessful}'), mbError, MB_OK);
    WizardForm.StatusLabel.Caption := StatusText;
  except
    if MsgBox(ExpandConstant('{cm:restorepointunsuccessful}' + #13#10 + #13#10 + '{cm:restorepointunsuccessful2}' + #13#10 + #13#10 + '{cm:restorepointunsuccessful3}'), mbconfirmation, mb_OKCANCEL) = idCANCEL then
    WizardForm.Close;
   end;
 WizardForm.StatusLabel.Caption := StatusText;

end;
end;
end;

//--------------------------------------------------------------------------------------------------------------------
// On demande si on veux effacer les sauvegardes
procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
var
UserFilesPath:string;
UserAppDataRoaming:string;
UserAppDataLocal:string;

begin
  case CurUninstallStep of
    usPostUninstall:
      begin
        UserFilesPath:=ExpandConstant('{userdocs}');
        UserAppDataRoaming:=ExpandConstant('{userappdata}');
        UserAppDataLocal:=ExpandConstant('{localappdata}');
        if MsgBox(ExpandConstant('{cm:backup}'), mbconfirmation, mb_yesno) = idyes then
        begin
          DelTree(UserFilesPath+'\ZGuideTVDotNet', True, True, True);
          DelTree(UserAppDataRoaming+'\ZGuideTVDotNet', True, True, True);
          DelTree(UserAppDataLocal+'\ZGuideTVDotNet', True, True, True);
        end;
      end;
  end;
end;

//--------------------------------------------------------------------------------------------------------------------

// On regarde si AppID est identique ou si c'est une nouvelle version !

function IsUpgrade(): Boolean;
var
   sPrevPath: String;
begin
  sPrevPath := '';
  if not RegQueryStringValue(HKLM, 'Software\Microsoft\Windows\CurrentVersion\Uninstall\{#emit SetupSetting("AppID")}_is1', 'UninstallString', sPrevpath) then
    RegQueryStringValue(HKCU, 'Software\Microsoft\Windows\CurrentVersion\Uninstall\{#emit SetupSetting("AppID")}_is1', 'UninstallString', sPrevpath);
  Result := (sPrevPath <> '');
end;

//------------------------------------------------------------------------------------------------------------------------

// Importation de l'API Windows ShowWindow Ã  partir du fichier User32.DLL

function ShowWindow(hWnd: Integer; uType: Integer): Integer;
external 'ShowWindow@user32.dll stdcall';

//----------------------------------------------------------------------------------------------------------------


function InitializeSetup(): boolean;
begin
	//init windows version
	initwinversion();

#ifdef use_iis
	if (not iis()) then exit;
#endif

#ifdef use_msi20
	msi20('2.0');
#endif
#ifdef use_msi31
	msi31('3.1');
#endif
#ifdef use_msi45
	msi45('4.5');
#endif
#ifdef use_ie6
	ie6('5.0.2919');
#endif

#ifdef use_dotnetfx11
	dotnetfx11();
#ifdef use_dotnetfx11lp
	dotnetfx11lp();
#endif
	dotnetfx11sp1();
#endif

	//install .netfx 2.0 sp2 if possible; if not sp1 if possible; if not .netfx 2.0
#ifdef use_dotnetfx20
	//check if .netfx 2.0 can be installed on this OS
	if not minwinspversion(5, 0, 3) then begin
		msgbox(fmtmessage(custommessage('depinstall_missing'), [fmtmessage(custommessage('win_sp_title'), ['2000', '3'])]), mberror, mb_ok);
		exit;
	end;
	if not minwinspversion(5, 1, 2) then begin
		msgbox(fmtmessage(custommessage('depinstall_missing'), [fmtmessage(custommessage('win_sp_title'), ['XP', '2'])]), mberror, mb_ok);
		exit;
	end;

	if minwinversion(5, 1) then begin
		dotnetfx20sp2();
#ifdef use_dotnetfx20lp
		dotnetfx20sp2lp();
#endif
	end else begin
		if minwinversion(5, 0) and minwinspversion(5, 0, 4) then begin
#ifdef use_kb835732
			kb835732();
#endif
			dotnetfx20sp1();
#ifdef use_dotnetfx20lp
			dotnetfx20sp1lp();
#endif
		end else begin
			dotnetfx20();
#ifdef use_dotnetfx20lp
			dotnetfx20lp();
#endif
		end;
	end;
#endif

#ifdef use_dotnetfx35
	//dotnetfx35();
	dotnetfx35sp1();
#ifdef use_dotnetfx35lp
	//dotnetfx35lp();
	dotnetfx35sp1lp();
#endif
#endif

#ifdef use_wic
	wic();
#endif

	// if no .netfx 4.0 is found, install the client (smallest)
#ifdef use_dotnetfx40
	if (not netfxinstalled(NetFx40Client, '') and not netfxinstalled(NetFx40Full, '')) then
		dotnetfx40client();
#endif

#ifdef use_dotnetfx46
    dotnetfx46(52); // min allowed version is .netfx 4.5.2
    //dotnetfx45(0); // min allowed version is .netfx 4.5.0
#endif

#ifdef use_vc2010
	vcredist2010();
#endif

#ifdef use_mdac28
	mdac28('2.7');
#endif
#ifdef use_jet4sp8
	jet4sp8('4.0.8015');
#endif

#ifdef use_sqlcompact35sp2
	sqlcompact35sp2();
#endif

#ifdef use_sql2005express
	sql2005express();
#endif
#ifdef use_sql2008express
	sql2008express();
#endif
	Result := true;
end;

//----------------------------------------------------------------------------------------------------------------------

// On ajoute une exception dans le Firewall Windows

procedure AddFirewallException();
var
strExeName: String;
vFWMgr, vProfile, vApps, vApp: Variant;

begin
WizardForm.ProgressGauge.Style := npbstMarquee;
strExeName := ExpandConstant('{app}\') + 'ZGuideTVDotNet.exe';
vFWMgr := CreateOleObject('HNetCfg.FwMgr');
vProfile := vFWMgr.LocalPolicy.CurrentProfile;
vApps := vProfile.AuthorizedApplications;
vApp := CreateOleObject('HNetCfg.FwAuthorizedApplication');
vApp.ProcessImageFileName := strExeName;
vApp.Name := 'ZGuideTV.NET';
vApp.Scope := 0;
vApp.IpVersion := 2;
vApp.Enabled := True; //This line...
vApps.Add(vApp);
end;

// On ajoute une fichier log dans le répertoire de l'application

procedure CurStepChanged(CurStep: TSetupStep);
var
  logfilepathname, newfilepathname: string;
  begin

  logfilepathname := expandconstant('{log}');

 newfilepathname := expandconstant('{app}\') +'ZGuideTVDotNet.Install.log'

 if CurStep = ssDone then
  begin
     filecopy(logfilepathname, newfilepathname, false);
  end;
       end;
