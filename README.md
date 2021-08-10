# Task List

## Task 1

- Create an api that POST the user one at a time  
  {  
  "FullName":"John Park",  
  "GroupName":"Avenger",  
  "Age":23  
  }
- Authorization type: Basic  
- Accepts only with request that has "username:BatMan123, password:heLOgen92"  

## Task 2 
- Create web application that has only one page "localthost/Roster"  
- That page should list the users who have joined the group called "Avenger" without page refresh    
- When api is hit from postman the user should be added to the list in Roster page without page refresh  and with pop up notification (use bootstrap) message "John joined the group".  
  Use the library Signal R to broadcast message on client side 
