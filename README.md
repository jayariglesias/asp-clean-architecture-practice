## WEB API - ASP .NET 3.1 CLEAN ARCHITECTURE PRACTICE
</br></br>
## API ENDPOINTS
  ## • USERS
  <Table>
    <thead>
        <tr>
          <th>METHOD</th>
          <th>POINT</th>
          <th>DESCRIPTION</th>
          <th>OBJECT</th>
        </tr>
    </thead>
    <tbody>
        <tr>
          <td><strong>GET</strong></td>
          <td>api/user/index</td>
          <td>Returns all users data.</td>
          <td>
           </td>
        </tr>
        <tr>
          <td><strong>GET</strong></td>
          <td>api/user/search/{id}</td>
          <td>Returns users data by its id.</td>
          <td>
           </td>
        </tr>
        <tr>
          <td><strong>POST</strong></td>
          <td>api/user/search</td>
          <td>Returns users data by its first name, lastname or both.</td>
          <td>
             {
                 "firstname": "Jayar",
                 "lastname": "Iglesias"
              }
           </td>
        </tr>
        <tr>
          <td><strong>POST</strong></td>
          <td>api/user/create</td>
          <td>Allows to create a user.</td>
          <td>
             {
                "firstname": "Jayar",
                "lastname": "Iglesias",
                "middlename": "Acabado",
                "email": "jiglesias@email.com",
                "username": "juser",
                "password": "jpass",
              }
           </td>
        </tr>
        <tr>
          <td><strong>PUT</strong></td>
          <td>api/user/update</td>
          <td>Allows to modify user data.</td>
          <td>
             {
                "userid": 1,
                "firstname": "Jayar",
                "lastname": "Iglesias",
                "middlename": "Acabado",
                "email": "jiglesias@email.com",
                "username": "juser",
                "password": "jpass",
              }
           </td>
        </tr>
        <tr>
          <td><strong>DELETE</strong></td>
          <td>api/user/delete</td>
          <td>Allows to delete user.</td>
          <td>
             {
                "userid": 1
              }
           </td>
        </tr>
    </tbody>
  </Table></br>
  
  ## • PETS
  <Table>
    <thead>
        <tr>
          <th>METHOD</th>
          <th>POINT</th>
          <th>DESCRIPTION</th>
          <th>OBJECT</th>
        </tr>
    </thead>
    <tbody>
        <tr>
          <td><strong>GET</strong></td>
          <td>api/pet/index</td>
          <td>Returns all pets data.</td>
          <td>
           </td>
        </tr>
        <tr>
          <td><strong>GET</strong></td>
          <td>api/pet/search/{id}</td>
          <td>Returns pets data by its id.</td>
          <td>
           </td>
        </tr>
        <tr>
          <td><strong>POST</strong></td>
          <td>api/pet/search</td>
          <td>Returns pets data by its name.</td>
          <td>
             {
                 "petname": "black",
              }
           </td>
        </tr>
        <tr>
          <td><strong>POST</strong></td>
          <td>api/pet/create</td>
          <td>Allows to create a pet.</td>
          <td>
              { 
                  "userid" : 1,
                  "pettype" : 1,
                  "petname" : "Black",
                  "breed" : "Wolf",
                  "birthdate" : "2021-08-08"
              }
           </td>
        </tr>
        <tr>
          <td><strong>PUT</strong></td>
          <td>api/pet/update</td>
          <td>Allows to modify pet data.</td>
          <td>
              { 
                  "petid" : 1,
                  "pettype" : 1,
                  "petname" : "Black",
                  "breed" : "Wolf",
                  "birthdate" : "2021-08-08"
              }
           </td>
        </tr>
        <tr>
          <td><strong>DELETE</strong></td>
          <td>api/pet/delete</td>
          <td>Allows to delete pet data.</td>
          <td>
             {
                "petid": 1
              }
           </td>
        </tr>
    </tbody>
  </Table></br>
  
  ## • VISITS
  <Table>
    <thead>
        <tr>
          <th>METHOD</th>
          <th>POINT</th>
          <th>DESCRIPTION</th>
          <th>OBJECT</th>
        </tr>
    </thead>
    <tbody>
        <tr>
          <td><strong>GET</strong></td>
          <td>api/visit/index</td>
          <td>Returns all visits data.</td>
          <td>
           </td>
        </tr>
        <tr>
          <td><strong>GET</strong></td>
          <td>api/visit/search/{id}</td>
          <td>Returns visit data by its id.</td>
          <td>
           </td>
        </tr>
        <tr>
          <td><strong>POST</strong></td>
          <td>api/visit/search</td>
          <td>Returns visits data by its last name, first name, pet name, pet type, visit type, visit from, visit to, or all of them.
          <td>
             {
                 "petname": "black",
                 "visitid": 1,
                 "petid": 1,
                 "visittype": 1,
                 "visitfrom": date,
                 "visitto": date,
                 "firstname": "owner",
                 "middlename" = "owner",
                 "lastname" = "owner"
              }
              </br></br>
              For range between dates, use this
              </br>
              {
                 "visitfrom": date,
                 "visitto": date,
              }
           </td>
        </tr>
        <tr>
          <td><strong>POST</strong></td>
          <td>api/visit/create</td>
          <td>Allows to create a visit.</td>
          <td>
              {
                  "petid" : 1,
                  "notes" : "okay, good, awesome",
                  "visittype" : 1,
                  "visitdate": "2021-05-05"
              }
           </td>
        </tr>
        <tr>
          <td><strong>PUT</strong></td>
          <td>api/visit/update</td>
          <td>Allows to modify visit data.</td>
          <td>
                {
                    "petid" : 1,
                    "notes" : "new notes",
                    "visittype" : 1
                }
           </td>
        </tr>
        <tr>
          <td><strong>DELETE</strong></td>
          <td>api/visit/delete</td>
          <td>Allows to delete visit data.</td>
          <td>
             {
                "visitid": 1
              }
           </td>
        </tr>
    </tbody>
  </Table></br>
  
## RESPONSE
The default response for all request.
```
{
  "status": Boolean,
  "message": String,
  "errors": String,
  "data": Object/Array
}
```
