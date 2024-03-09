# Workdays / sessions
## And What i found out


# Session 1

**Movement System**
I decided on using the most simple and well documented form of movement, that i could find. So i ended up using the older "Input Manager" 
to control my player. 

**Camera System**
Decided on currently just having the camera follow the player from a perfect 90 degree top down view. Don't know if anything else is possible, but i will look into that later.

**Tilemap**
I tried going a bit into texturing and tilemapping, to get a feel for how it works. I had hoped i would be able to make a simple tilemap. Currently i am only able to seperate grass and wooden walls on their own layers called "Ground" and "Collisions" respectively.
This way i should have some strong foundations going forward.


# Session 2

**Redid the movement system** 
I had a lot of trouble with the older system so i spend a couple of hours figuring out how to switch to the new one.

**Building an interaction system**
Tried a "Ray" approach, where i will upon pressing a button, shoot a ray. And if i hit something of type "Interactable", it shoots an event. 

**Thinking in composition**
Composition is pretty hard to "think" in, i keep wanting to put stuff in a very layered architecture. So i repeatedly end up with massive logic classes that could have its logic split out smarter.


# Session 3
**New Interaction System**
I didn't like how jagged the ray felt, so i switched to having a "Interaction Center" in front of my player character. And upon pressing Interact. It checks in a circle around itself. This way the interaction system is way more forgiving. I like it a lot more

**Began trying to make UI**
Its hard to find tutorials that go in depth, so i am just going on ahead to try. I implemented some helping logic classes for RPG Class and Guildmembers and such


# Session 4
**Working on UI**
Putting words into the UI is very hard, like having some specific objects with values, and then putting those values into the UI to show to the player. It is quite hard for me, i have tried for around 4-5 hours to make a UI system that i like. And i just seem to not find something that i am happy with. Also, currently i am just making random characters, i think i would rather like to make some custom made ones. So that when someone gets the character "Jeff", then other players would know what is talked about. 

I made some UI work, but i am not happy about it. And i still have not found a way to make a "Tavern" object fit properly into the world :D 

**Folder structure**
I tried searching for ways people have their own folder structure, but i cant seem to find a template that makes sense. 
So i tried making my own. But i cant seem to find a folder structure that can seperate the logic. Since much from one folder is "bleeding" out logic into others. I will see if i can find a better solution in the future
# Session 5
**Redoing the UI system**
I think i found a solution, and it is called ScriptableObject, i think i will use these to fill out my UI elements. I still however need to find some good ways to subscribe to children events in my UI. 

**Creating the Tavern object**
I made the tavern, it is an object that i can put a script into, it has its own health and inventory. It's very cool!
