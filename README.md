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
                 "firstname": string,
                 "lastname": string
              }
           </td>
        </tr>
        <tr>
          <td><strong>POST</strong></td>
          <td>api/user/create</td>
          <td>Allows to create a user.</td>
          <td>
             {
                "firstname": string,
                "lastname": string,
                "middlename": string,
                "email": string,
                "username": string,
                "password": string,
              }
           </td>
        </tr>
        <tr>
          <td><strong>PUT</strong></td>
          <td>api/user/update</td>
          <td>Allows to modify user data.</td>
          <td>
             {
                "userid": number,
                "firstname": string,
                "lastname": string,
                "middlename": string,
                "email": string,
                "username": string,
                "password": string,
              }
           </td>
        </tr>
        <tr>
          <td><strong>DELETE</strong></td>
          <td>api/user/delete</td>
          <td>Allows to delete user.</td>
          <td>
             {
                "userid": number
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
                 "petname": string,
              }
           </td>
        </tr>
        <tr>
          <td><strong>POST</strong></td>
          <td>api/pet/create</td>
          <td>Allows to create a pet.</td>
          <td>
              { 
                  "userid" : number,
                  "pettype" : number,
                  "petname" : string,
                  "breed" : string,
                  "birthdate" : date
              }
           </td>
        </tr>
        <tr>
          <td><strong>PUT</strong></td>
          <td>api/pet/update</td>
          <td>Allows to modify pet data.</td>
          <td>
              { 
                  "petid" : number,
                  "pettype" : number,
                  "petname" : string,
                  "breed" : string,
                  "birthdate" : date
              }
           </td>
        </tr>
        <tr>
          <td><strong>DELETE</strong></td>
          <td>api/pet/delete</td>
          <td>Allows to delete pet data.</td>
          <td>
             {
                "petid": number
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
                 "petname": string,
                 "visitid": number,
                 "petid": number,
                 "visittype": number,
                 "visitfrom": date,
                 "visitto": date,
                 "firstname": string,
                 "middlename": string,
                 "lastname": string
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
                  "petid" : number,
                  "notes" : string,
                  "visittype" : number,
                  "visitdate": date
              }
           </td>
        </tr>
        <tr>
          <td><strong>PUT</strong></td>
          <td>api/visit/update</td>
          <td>Allows to modify visit data.</td>
          <td>
                {
                    "petid" : number,
                    "notes" : string,
                    "visittype" : number
                }
           </td>
        </tr>
        <tr>
          <td><strong>DELETE</strong></td>
          <td>api/visit/delete</td>
          <td>Allows to delete visit data.</td>
          <td>
             {
                "visitid": number
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
  "errors": String/Arrays,
  "data": Object/Array
}
```
