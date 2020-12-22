<h3>A studies project of TCP server and client in C#</h3>

Simple login and comunication with all responses and users saved inside a MSSQL database. 
All needed info about database is inside Database.sql.

Communication is simple message exchange:
1. Client must send login credentials until passing correct ones
2. Server responds with info about provided credentials
3. When client passed correct data, is allowed to chat with server with responses 
specified in database or a special type message being command.

---

Special commands

---

Admin
- getall
- userdel @login
- useradd @login @password @permission


---

Normal User
- usermod @login @newpassword
- random @min @max


---
