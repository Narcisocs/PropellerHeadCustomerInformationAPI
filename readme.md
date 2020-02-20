The entire API was designed using .NET Core WebAPI and once built can be tested using postman program by just changing controller in the url and the http verb with exception 
of some methods which require a specific url that can be found in the route annotation attribute. The requirement "Get all notes for a customer." is an example of that.
The user should build the API using the "PropellerheadCI.Api" launching profile and then test through postman.

I have spent an afternoon and a night to build this API and if I had more time I would like to improve more on the security area of the API which in the current moment is open 
to everyone.