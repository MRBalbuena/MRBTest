Notes:
I assume I can fix the whole module, so I updated DB datatypes and added PK.
For a real proyect: 
I would use a IoC, that's why UserService expects a IUserRepository object.
I would defenitely remove the dependency of User to UserData. For that I would split the Model putting the UserModel.tt in a different project.
I would add a new project for Dto classes accessible for all projects.
I would split abstractions to its own project.
As this aproach is based on abstractions (interfaces) it's possible to test the service using a mock repository.
