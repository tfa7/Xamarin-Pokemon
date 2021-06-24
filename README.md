# Xamarin Pokémon Demo

This is a sample android mobile application using pokeapi (https://pokeapi.co/) and Xamarin. 

## Requirments
Get a Xamarin application connecting to <a href="https://pokeapi.co/" target="_blank">Poke Api</a>

A working Angualar version of this project is available <a href="https://github.com/tfa7/Angular-Pokemon" target="_blank">https://github.com/tfa7/Angular-Pokemon</a>

## Screenshots

Available in the screenshots folder

## Why Xamarin

1. fully mobile
2. supports Android, IOS and UWP
3. has a large community for support 
4. ideal for .net developers

## Run Locally

To run this project locally:
1. download the repo
2. build the project in visual studio 
3. run the application 

## Project Details

### Working
1. splash screen 
2. retreiving and displaying the list of Pokemons
3. clicking on a Pokemon displays the requested Pokemon detail
4. filtering Pokemon by text search works

### Not Working
1. Filter by type
2. Caching and saving to Sqlite
3. Navigation

Because the Angular project was completed first I did not have enough time to complete this. The reason the Angular project was completed first is because I was sure I had enough time and experience to get all the functionality completed in Angular.

## Development Details

### Activities, Presenter and Layout Folders
1. HomeActivity: splash screen titled "Pokemon Demo App" -> "Presenter/HomePresenter" -> "Resources/layout/HomeScreenLayout"
2. DisplayPokemonActivity: displays the grid list of Pokemons -> "Presenter/DisplayPokemonPresenter" -> "Resources/layout/ViewPokemonLayout" & "Resources/layout/GridViewLayout"
3. PokemonDetailsActivity: displays the Pokemon item -> "Presenter/PokemonDetailsPresenter" -> "Resources/layout/PokemonDetailsLayout"

### Model and Service Folder
1. Entity: contains the main Pokemon model class
2. Service: calls the Pokemon Api and deserialises the data to the models

### Resources Folder
1. Contains a list of images for each Pokemon. A hack was implemented for the 'Resources\drawable' folder to name the image "pokemon_XXX.png" where XXX maps the Pokemon name.

Note: AndroidExtenstions->CustomImageAdapter is where the images are mapped. When an image is not found the image could be got using "GetImageBitmapFromUrl" and saved to the local folder folder using the "pokemon_XXX.png" format.

### Utilities Folder
1. List of constants variables  

### Sqlite 
The setup is there but the project is not using this at the moment

## Testing
No tests were created for this project.

## Hindsight
Create a blank new template in Visual Studio using the latest Xamarin tools/packages.

## Template
Due to time constraints this project used <a href="https://github.com/mdcruz/pokedex" target="_blank">https://github.com/mdcruz/pokedex</a> as a template. 
