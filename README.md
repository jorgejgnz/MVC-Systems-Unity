# Isolated systems (MVC) for Unity

**Entity Component System (ECS)** is the pattern that is used in Unity's data-oriented tech stack. This data-oriented philosophy comes from the need of parallelization and optimization in videogames.

**Model View Controller (MVC)** is a well-known object-oriented pattern that preserves a clear separation between data-storage (model), presentation (view) and business logic (controller). This pattern has been used for desktop and web applications as it keeps the application scalable and maintenable.

These patterns follow different philosophies and they are not intended to be combined but it's possible to get the benefits from both if this MVC pattern is used to implement isolated systems or subsystems in your game when they fulfill the following **requirements**:
- It represents a functionality or feature that is present in multiple scenes
- It can have scene-specific configurations
- It listents to events invoked from other systems
- It doesn't listen to events invoked from scene-specific components
- It contains data that other systems or scene-specific components can read
- It invokes its own evemts, which can be listened by other systems or otherr scene-specific components

# Content
- Functional MVC system (SimpleSystem)
- Skeleton for systems with hierarchical models
- Skeleton for modular systems
- Network and file parsing helpers
- Demo scene with a scene-specific component that interacts with SimpleSystem

# Getting started
1. Clone this repository or get the latest released package.
1. Copy these files or import the package into your Unity project.
1. Press play:
- CustomComponent will print your IP and the number of times you played the scene.
- CustomComponent has a button (custom inpsector) that changes the color of a cube.

## Model

### Scene-specific model

MonoBehaviour component which only contains public variables and any business logic apart from initialization of variables. As it is a MonoBehaviour, it has to be present in the scene allowing different data for different scenes. This model contains references to the other model types (optional), which are described in the following sections.

This component should only be referenced and accesed by the Controller. Nothing impedes this component to be referenced and accesed from scene-specific components but this is a bad practice as, if accesed by many components, it will be harder to control changes in this model and it will take longer to debug unwanted modifications of the data contained in the model.

Model can have child models to group data into understandable blocks of information which are easier to manage. These child models are also MonoBehaviour components and they should include a reference to its parent. These reference is not set manually but by the Controller (see Controller section) and, in fact, it should be hidden in Inspector to avoid this operation to be manual.

For consistency, their GameObjects should be placed under the Model's GameObject to maintain the hierarchy visible also in the Hierarchy window.

> Model also can contain a reference to the system View but this is redundant as this View is already referenced in the Controller.

### Persistent model

We might need data that persist between scenes (locally or remotely). There are many ways to accomplish this and this generic class act as an interface to these other data-storages by exposing properties which can be read by the Controller.¡ like any other variable.

It can be extended with async operations by including functions for requests and events for results. If the Controller wants some data that is accessible through a RESTful API, it can call a function of this class and listen to a specific event for that value. The function will internally trigger the request and when the response is received and formatted, it is sent as a parameter in an invoked event.

In this example only PlayerPrefs is used for the sake of simplicity.

### Configuration asset

Configuration assets are ScriptableObjects and, like any other asset, they will keep existing if the scene is changed and therefore they can be referenced between scenes.

These assets are useful if we need a list of preset configurations that are available across the scenes.

These configuration assets can be created by doing right-click in Project View and selecting the path specified in the CreateAssetMenu attribute of the class of that Configuration Asset.

## View

MonoBehaviour that only contains properties (ViewModel) and events that can be accesed/listened by other systems or scene-specific components. By exposing properties instead of directly variables enables us to get a better control on read/write operations over the model so we can trigger events, filter controller-only variables or offering readonly data that can be written only by Controller.

As it is a MonoBehaviour, it can be referenced by other scene-specific components or by the model of other systems.

### Singleton

If this system is unique in the scene (only one instance), it is better to expose a singleton of its instance as a static variable that can be access anywhere through the class of its View, making the aforementioned references uneccesary.

### Events

UnityEvents are exposed in the View for other components to listen.

Views shouldn't contain functions. If some component require the system to perform an action, it will invoke an event exposed in the View that is specific for that action. This way, if we need other systems or components to be aware of these operations, they can listen to these events too without the need of extra logic.

Events can transmit or contain parameters. The given exmaple includes a custom event that can contain float values.

### ViewModel

View has to be accessible to external components, View has to access the model and extra components are not allowed to access the model (not even by casting). This can be done by including a custom, nested and sealed class inside the View class that only contains properties.

ViewModel has a private reference to Model which is set only on its constructor, which must be called only by Controller (see Controller section).

View class can contain multiple nested sealed classes to implement hierarchies of ViewModels but, as ViewModels don't storage data, these children ViewModels are instantiated on every read and their references shouldn't be stored or compared.

> The condition _VieModel.ChildViewModel == ViewModel.ChildViewModel_ will always be false as ChildViewModel is reinstantiated on every read operation. 

## Controller

This component implements the businss logic of the system.

As it is a MonoBehaviour, it is governed by MonoBehaviour's lifecycle so we can use its Start, Update and FixedUpdate functions for our benefit.

This component contains the references to View and Model. On its Awake function it will instantiate View.ViewModel, passing the reference to the Model, and it will add the reference to the View in the Model (optional).

### Components connection

Model, View and Controller are MonoBhevaiour components that must be present in the Scene, this way we even group them and store the whole system as a prefab that can be drag & droped into any Scene to enable/disable a feature or functionality for that specific Scene.

### Registry

This pattern supports the existence of specific and generic systems. We will refere to specific systems as modules, as they are isolated extensions of a bigger system in our application.

In order to accomplish this, we would need a global view class that we can call GlobalView. Module's view class would inherit from this class.

A module would be also a MVC system following the same structure as a generic system but its model would contain a reference to the model of the generic system so it can access the generic model directly. Generic model would have a list of "connected" modules (List<GlobalView>).

Module's controller would register itself in the module registry of the generic system by adding its view to the list of "connected" modules.

Module controller will have access to generic model directly but not to its connected modules which are only accessible through their views by going through the list of connected modules in the generic model until finding the view that can be casted to the desired specific view. Generic model will only have acces to the modules through their views. This leads to better security and maintainability as the modules remain isolated from each other even when they are connected.

# Author
**Jorge Juan González** - *HCI Researcher at I3A (University of Castilla-La Mancha)*

[LinkedIn](https://www.linkedin.com/in/jorgejgnz/) - [Twitter](https://twitter.com/jorgejgnz) - [GitHub](https://github.com/jorgejgnz)

# License
[MIT](./LICENSE.md)