1.	Steps to add a Entity (Kickstarter.Library)
====================================================
1.1		Define the Interface in Kickstarter.Library.Interfaces
1.2		Create a xUnit Test for the new entity in KickStarter.Library.Tests.Entity
1.3		Create the new entity in Kickstarter.Library.Entities
1.4		Compose the xUnit test according to the requirements
1.5		Complete the entity so it passes the test (TIP! do one propery at a time)

2.	Steps to add a component for the entity (Kickstarter.BusinessLayer)
=======================================================================
2.1		Create a new interface for the component in Kickstarter.BusinessLayer.Components.Interfaces
2.2		Create a folder in Kickstarter.BusinessLayer.Components with the name of the new component
2.3		Create the new component the above folder
2.4		Create a folder in Kickstarter.BusinessLayer.Tests.Components with the name of the new component
2.5		Create a mapping profile in KickStarter.BusinessLayer.Components.BusinessLayerMappingProfile
2.6		Create a map in KickStarter.DataLayer.Map with the name of the new EntityMap
2.7		Add the just created map to KickStarter.DataLayer.EntityFramework.DataContext.OnModelCreating
2.8		Create a xUnit Test for the new component in above folder
2.9		Compose the xUnit test according to the requirements
2.10	Complete the component so it passes the test (TIP! do one task at a time)

3.	Steps to add a service for the new entity (Kickstarter.Service)
=======================================================================
3.1		Add a Clientmodel for the new entity in Kickstarter.Service.ClientModels
3.2		Add an Interface for the controller with the name of the new entity in Kickstarter.Service.Controllers.api.Interfaces
3.3		Add a Controller for the new entity in Kickstarter.Service.Controllers.api
3.4		Add a entity to Model Typeconverter for the new entity in KickStartrer.Service.Conversion
3.5		Create a xUnit test in Kickstarter.ServiceLayer.Tests.Controller.api with the name of the new controller
3.6		Compose the xUnit test according to the requirements
3.7		Create a xUnit test in KickStarter.ServiceLayer.Tests.Conversions with the name of the new TypeConverter
3.8		Compose the xUnit test for the mapping both way's
3.9		Complete the controller so it passes the test (TIP! do one action at a time)

4.	Steps to add a dataservice for the new entity (KickStarter.DataLayer)
=======================================================================
4.1		Add a virtual DBSet in KickStarter.DataLayer.EntityFramework.DataContext