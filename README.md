### About SuperDB

SuperDB is an ultra-lightweight and portable database system written in pure C# with no external dependancies. It can be used almost anywhere for about any purpose. it can store any normal C# type or byte array into a container.
<hr/>

### How to use
The usage of SuperDB is very simple and is easy to set up.
- Include SuperDB into your project.
- Add it's using to your files with ``using SuperDB;``
- Create an instance of SuperDB. There are two ways you can do it:
    - Create a blank database with ``Database DB = new();``
    - Open an existing database with ``Database DB = new(BinaryOfDatabase);``
- Read and Write to the database with whatever data you are using.
- Finaly, export the data either to a byte array, or to a file by including a path argument to ``Export();``
<hr/>

###### SuperDB is licensed under GPL V2.0