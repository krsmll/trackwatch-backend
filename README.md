# trackwatch-backend

---
### **Idea**

There is an overwhelming amount of movies and series available to watch for a person. Thing is, sometimes it either hard to remember whether a move is good or if you've already seen it before. There are multiple services like this aimed at tracking anime, a style of animation native to Japan, and some that track movies exclusively, yet there are no such thing as a service that combines those together. Here's where **trackWatch** comes in.

**trackWatch** is a manual tracking system for whatever is possible to watch or consume. Movies, series, books, you name it. The system can handle it.

---
**Migrations**
~~~
dotnet ef migrations --project DAL.App.EF --startup-project WebApp add InitialMigration --context DAL.App.EF.AppDbContext
dotnet ef database --project DAL.App.EF --startup-project WebApp update --context DAL.App.EF.AppDbContext
dotnet ef database --project DAL.App.EF --startup-project WebApp drop --context DAL.App.EF.AppDbContext
~~~

---
**MVC Web Controllers**
~~~
dotnet aspnet-codegenerator controller -name CharactersController -actions -m  Domain.App.Character -dc DAL.App.EF.AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name CharacterInListsController -actions -m  Domain.App.CharacterInList -dc DAL.App.EF.AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name CharacterPersonsController -actions -m  Domain.App.CharacterPerson -dc DAL.App.EF.AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name CharacterPicturesController -actions -m  Domain.App.CharacterPicture -dc DAL.App.EF.AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name CoverPicturesController -actions -m  Domain.App.CoverPicture -dc DAL.App.EF.AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name FavCharacterListsController -actions -m  Domain.App.FavCharacterList -dc DAL.App.EF.AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name FormatsController -actions -m  Domain.App.Format -dc DAL.App.EF.AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name GenresController -actions -m  Domain.App.Genre -dc DAL.App.EF.AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name PersonsController -actions -m  Domain.App.Person -dc DAL.App.EF.AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name PersonPicturesController -actions -m  Domain.App.PersonPicture -dc DAL.App.EF.AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name RatingScalesController -actions -m  Domain.App.RatingScale -dc DAL.App.EF.AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name RolesController -actions -m  Domain.App.Role -dc DAL.App.EF.AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name StatusesController -actions -m  Domain.App.Status -dc DAL.App.EF.AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name WatchListsController -actions -m  Domain.App.WatchList -dc DAL.App.EF.AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name WorksController -actions -m  Domain.App.Work -dc DAL.App.EF.AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name WorkAuthorsController -actions -m  Domain.App.WorkAuthor -dc DAL.App.EF.AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name WorkAuthorRolesController -actions -m  Domain.App.WorkAuthorRole -dc DAL.App.EF.AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name WorkCharactersController -actions -m  Domain.App.WorkCharacter -dc DAL.App.EF.AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name WorkGenresController -actions -m  Domain.App.WorkGenre -dc DAL.App.EF.AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name WorkInListsController -actions -m  Domain.App.WorkInList -dc DAL.App.EF.AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name WorkRelationsController -actions -m  Domain.App.WorkRelation -dc DAL.App.EF.AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name WorkTypesController -actions -m  Domain.App.WorkType -dc DAL.App.EF.AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
~~~

---
**API Controllers**
~~~
dotnet aspnet-codegenerator controller -name CharactersController -m  Domain.App.Character -actions -dc DAL.App.EF.AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name CharacterInListsController -m  Domain.App.CharacterInList -actions -dc DAL.App.EF.AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name CharacterPersonsController -m  Domain.App.CharacterPerson -actions -dc DAL.App.EF.AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name CharacterPicturesController -m  Domain.App.CharacterPicture -actions -dc DAL.App.EF.AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name CoverPicturesController -m  Domain.App.CoverPicture -actions -dc DAL.App.EF.AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name FavCharacterListsController -m  Domain.App.FavCharacterList -actions -dc DAL.App.EF.AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name FormatsController -m  Domain.App.Format -actions -dc DAL.App.EF.AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name GenresController -m  Domain.App.Genre -actions -dc DAL.App.EF.AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name PersonsController -m  Domain.App.Person -actions -dc DAL.App.EF.AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name PersonPicturesController -m  Domain.App.PersonPicture -actions -dc DAL.App.EF.AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name RatingScalesController -m  Domain.App.RatingScale -actions -dc DAL.App.EF.AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name RolesController -m  Domain.App.Role -actions -dc DAL.App.EF.AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name StatusesController -m  Domain.App.Status -actions -dc DAL.App.EF.AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name WatchListsController -m  Domain.App.WatchList -actions -dc DAL.App.EF.AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name WorksController -m  Domain.App.Work -actions -dc DAL.App.EF.AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name WorkAuthorsController -m  Domain.App.WorkAuthor -actions -dc DAL.App.EF.AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name WorkAuthorRolesController -m  Domain.App.WorkAuthorRole -actions -dc DAL.App.EF.AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name WorkCharactersController -m  Domain.App.WorkCharacter -actions -dc DAL.App.EF.AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name WorkGenresController -m  Domain.App.WorkGenre -actions -dc DAL.App.EF.AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name WorkInListsController -m  Domain.App.WorkInList -actions -dc DAL.App.EF.AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name WorkRelationsController -m  Domain.App.WorkRelation -actions -dc DAL.App.EF.AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name WorkTypesController -m  Domain.App.WorkType -actions -dc DAL.App.EF.AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
~~~

---
**Scaffolding**
~~~
dotnet ef dbcontext scaffold --project DAL --startup-project WebApp Name=ConnectionStrings:DefaultConnection Microsoft.EntityFrameworkCore.SqlServer --data-annotations --context DAL.App.EF.AppDbContext --output-dir Models
~~~