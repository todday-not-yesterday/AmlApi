<!--This is a simple setup often used for RESTful APIs in documentation or code comments, especially in OpenAPI or Swagger-style formats.
You should include as markdown file in your github repository and include the link to the folder in the report.-->

# Media Controller
**Endpoint**: POST /Media/BorrowMedia/{mediaKey}/{userKey} 
**Description**: Creates a UserInventory with the status set to borrowed.

**Headers**:

- `Authorization`: Bearer [token] (required)
- `Content-Type`: application/json

**Request Body**:

- No body request

**Query Parameters**:

- `mediaKey` (type: int, required): References the unique key for media.
- `userKey` (type: int, required): References the unique key for user.

***Response***:

- Status: 200 Success
- Body: 

```json
{
  "success": "true", 
  "message": "The Book Lord of the rings has been successfully borrowed" 
}
```

***

# Search Controller
**Endpoint**: POST /Search/GetMedia
**Description**: Gets mapped media resources based on filters.

**Headers**:

- `Authorization`: Bearer [token] (required)
- `Content-Type`: application/json

**Request Body**:

```json
{
  "pageNumber": 0,
  "pageSize": 0,
  "searchItem": "string",
  "userKey": 0,
  "mediaTypes": [
    0
  ],
  "branches": [
    0
  ],
  "mediaEnquiryType": 0,
  "publicationYear": 0
}
```

***Response***:

- Status: 200 Success
- Body: 

```json
{
  "mediaResources": [
    {
      "key": 8,
      "name": "Dream of the Red Chamber",
      "author": "Cao Xueqin",
      "publicationYear": 1791,
      "mediaType": "Book",
      "available": true,
      "branchName": "Adsetts Centre",
      "stockLevel": 1
    }
  ],
  "mediaCount": 1
}
```

***

**Endpoint**: GET /Search/GetMediaTypes
**Description**: Gets all media types so they can be used to filter.

**Headers**:

- `Authorization`: Bearer [token] (required)
- `Content-Type`: application/json

**Query Parameters**:

- No query parameters

***Response***:

- Status: 200 Success
- Body: 

```json
[
  {
    "key": 1,
    "name": "Book"
  },
  {
    "key": 3,
    "name": "Journal"
  },
  {
    "key": 4,
    "name": "DVD"
  },
  {
    "key": 5,
    "name": "Game"
  }
]
```

***

**Endpoint**: GET /Search/GetBranches
**Description**: Gets all media branches so they can be used to filter.

**Headers**:

- `Authorization`: Bearer [token] (required)
- `Content-Type`: application/json

**Query Parameters**:

- No query parameters

***Response***:

- Status: 200 Success
- Body: 

```json
[
  {
    "key": 1,
    "name": "Adsetts Centre"
  },
  {
    "key": 2,
    "name": "Newfield Green Library"
  },
  {
    "key": 3,
    "name": "Sheffield city archives"
  }
]
```

# User Controller
***

**Endpoint**: GET /User/Login?username=&password=
**Description**: Returns boolean that is evaluated if user exist or not.

**Headers**:

- `Authorization`: Bearer [token] (required)
- `Content-Type`: application/json

**Query Parameters**:

- `username` (type: string, required): References the user's name.
- `password` (type: string, required): References the user's password.

***Response***:

- Status: 200 Success
- Body: 

```json
	true
```

***

**Endpoint**: POST /User/Register
**Description**: Creates a User entity in the system.

**Headers**:

- `Authorization`: Bearer [token] (required)
- `Content-Type`: application/json

**Request Body**:

```json
{
  "key": 0,
  "firstName": "string",
  "lastName": "string",
  "address": "string",
  "postCode": "string",
  "email": "string",
  "dateOfBirth": "2024-12-02T06:15:05.940Z",
  "contactNumber": "string",
  "userName": "string",
  "password": "string",
  "consent": true,
  "isVerified": true,
  "userLevel": 0
}
```

***Response***:

- Status: 200 Success
- Body: 

```json
{
  "message": "Registration successful"
}
```

# Inventory Controller
***

**Endpoint**: POST /Inventory/TransferMedia
**Description**: Transfers media to a new branch and creates records if media does not exist in other branch.

**Headers**:

- `Authorization`: Bearer [token] (required)
- `Content-Type`: application/json

**Request Body**:

```json
{
  "key": 0,
  "branch": 0,
  "stockLevel": 0
}
```

***Response***:

- Status: 200 Success
- Body: 

```json
	"Transferred Media Successfully"
```