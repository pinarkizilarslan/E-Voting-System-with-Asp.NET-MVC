## E-Voting-System-with-Asp.NET-MVC

It is an E-Voting system made in the Asp.NET MVC project. Information such as voter, candidate, vote, e-mail, password are stored in the database.

### Methodology
The system will be built on a web based Asp.NET MVC project. Voter information, candidate information, vote papers, election results will be kept in a relational database. The votes used will be recorded in the database with the RSA encryption algorithm. General operation will be as follows, voters access a panel where they can vote after logging into the system with their username and password. Candidate information is listed on the panel and the voter uses the vote. After the voting is over, the votes cast are counted and the results are displayed graphically in the system.

###	Interface
A website that has both an interface for voters and a management panel will be developed. A system will be established where voters can vote, view results of votes, and view candidate information. Design part will be established with HTML, CSS, JS and Bootstrap libraries. It will be studied in C # programming language. ASP.NET Core project and MVC framework will be used on Visual Studio 2017 Community.

### Dataset
Microsoft SQL Server Management Studio 2018 version 15.0.00.5 will be used as the database system. Entity Framework will be used for operations such as CRUD transactions on the system. Adding data will be done with JQuery, which is a JS library.

###	Encryption Algorithms
The passwords of the voters used in system login will be encrypted with Crypto Helpers and MD5 encryption function will be used. RSA algorithm will be used for encryption of votes. For this, the System.Security.Cryptography library will be used. 
<br />

### Web interface pictures of the system

<img width="392" alt="Resim1" src="https://user-images.githubusercontent.com/63308712/112643983-f80e8e80-8e55-11eb-8e40-2c58dac89a9b.png">
Fig.1 The system architecture
<br />
<br />

<img width="251" alt="Resim2" src="https://user-images.githubusercontent.com/63308712/112648823-f3000e00-8e5a-11eb-8dac-f325b8b5d2a0.png">
Fig.2 In order to log into the system, e-mail - password is verified for the user and the administrator on the login screen
<br />
<br />
<br />

![Resim3](https://user-images.githubusercontent.com/63308712/112649106-30649b80-8e5b-11eb-8427-7a7849065cd2.png)
*Fig.3 The home page of the E-Voting system where voters log in to vote*
<br />
<br />
<br />

![Resim4](https://user-images.githubusercontent.com/63308712/112650563-90a80d00-8e5c-11eb-880f-a89819ccca90.png)
*Fig.4 Voting screen where voters see candidates and cast their votes*
<br />
<br />
<br />

![Resim5](https://user-images.githubusercontent.com/63308712/112650752-c3ea9c00-8e5c-11eb-91fa-9cb7d69b30bd.png)
*Fig.5 Dashboard of the admin system*
<br />
<br />
<br />

![Resim7](https://user-images.githubusercontent.com/63308712/112650999-0318ed00-8e5d-11eb-8d39-0a3933713b34.png)
*Fig.7 Admin panel where candidates are listed*
<br />
<br />
<br />

<img width="411" alt="Resim1" src="https://user-images.githubusercontent.com/63308712/112651274-4bd0a600-8e5d-11eb-93c0-6b66cebb5d05.png">
Fig.8 Admin panel where result of the selection are listed
<br />
