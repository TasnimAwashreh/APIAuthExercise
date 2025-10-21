# Welcome to the API + Authentication Excercise
## How to Use:

1) Run the application
2) Open Postman

There are currently two requests a user can do:
___
### Login: 

POST http://localhost:5029/Auth/login
Example Body:
>{
>  "username": "admin",
>  "password": "pass123"
>}
___
### Validate: 

> POST http://localhost:5029/Auth/validate

Example Body:
>{
>    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiI1YTFjZmJhZC1kNzIyLTQ0MjUtOGJhMS05ZTQ5MmJhYjQ4N2IiLCJzdWIiOiJhZG1pbiIsIm5iZiI6MTc2MTAzMTUyNSwiZXhwIjoxNzYxMDM1MTI1LCJpYXQiOjE3NjEwMzE1MjUsImlzcyI6Imh0dHBzOi8vZm9vdGhpbGxzb2x1dGlvbnMuY29tIiwiYXVkIjoibG9jYWxob3N0In0.2oc0uU4gxxQBZl-rdmi-azR2O3qbMSJALBPcdj01bOo"
>}

Notes: 
- Please add the token in the header as a bearer token as well
- Token may be expired as they last about a day