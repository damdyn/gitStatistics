using Soneta.Business.Licence;
using Soneta.Business.UI;
using enova365.Git2;

[assembly: FolderView("Git",
    Priority = 10,
    Description = "Dostęp do aktualnego repozytorium",
    BrickColor = FolderViewAttribute.BlueBrick,
    //Icon = "Soneta.Examples.Utils.examples.ico;Soneta.Examples",
    Contexts = new object[] { LicencjeModułu.All }
)]

[assembly: FolderView("Git/Ilość komitów dziennie",
    Priority = 12,
    Description = "Na osobę",
    ObjectType = typeof(CommitsPerDayByUserForm),
    ObjectPage = "CommitsPerDayByUser.general.pageform.xml",
    ReadOnlySession = false,
    ConfigSession = false
)]
[assembly: FolderView("Git/Średnia ilość komitów na dzień",
    Priority = 12,
    Description = "Na osobę",
    ObjectType = typeof(AvarageCommitNumberPerUserForm),
    ObjectPage = "CommitsPerUser.general.pageform.xml",
    ReadOnlySession = false,
    ConfigSession = false
)]


