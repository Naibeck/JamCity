# JamCity test

Hi, let me introduce to the key points in the code for the challenge.

## Data Layer
The data layer is capable of receiving different data sources based on the repository pattern, currently the repository 
is only capable of fetching the data but storing, updating, sorting, deciding what data source to use could also be a 
responsible for the repository for some cases. e.g Favoring serving cache data over requesting a new network request.

The repository is the main entry point of BL for the data layer since is the one taking the decisions for how and what 
data to retrieve.

## Use Cases
Each use case represent a simple BL execution; is based on the command pattern allowing the different behaviors for each 
way to calculate the salaries increase each year. This allow to update each one of the current positions if required or 
append new positions with their own way of calculate the yearly salary increase.

## Repository
This is a bit odd it is not a completely Presenter architecture having an IView and IPresenter as way to communicate, but
is closer of using a VM approach using a one-way binding in this particular case by just exposing the returning value, the 
big difference about not being a VM pattern is that the way that the View receive that data updates is not using an 
Observer pattern. 

## Calculate Module (DI)
Calculate module is based on the Service Locator pattern, so you can register each class in a dictionary and assign a 
context defining who can have access to that specific instance. This was cool to see in practice because it ended up 
being similar to [Hilt - Dagger](https://dagger.dev/hilt/modules), defining a large file defining the dependencies an how
each of them know each other.

## Unity features
Data sources are being defined using Prefabs, the quantity of employees and their position is using a Prefab and the DataSource
is using that parameters to create the Workers data that is being used by the repository. You could define multiple of those in case
you want to adjust the quantity on each employee.
