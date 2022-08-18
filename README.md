# PortfolioWebsiteApp

Live URL: https://yunfolio.azurewebsites.net/

This site uses Identity Framework to implement user registration and login features with Admin vs User roles. Each new user registering with the site must validate
their email address with 6-digit code they receive from SMPT email service (must check Spam folder to find the email). Nearly all contents of every page can be 
dynamically edited and stored into the database (accessible only when client is logged in with an admin account). There is very little site content written in static 
HTML pages. 

Pictures are not stored directly inside the database and instead in photo storage API service called Cloudinary so it is a little slow.

Whenever a POST request is received from the client, the site redirects the route with Ajax and JQuery to perform the POST action without loading an entirely new page.
This feature is not available for the email confirmation process. The site's developer (me: Yunho) was learning ASP.NET for the first time and only learned JQuery after
the Identity Framework implementations. The site's development process shows that the code are both original and a reflection of my ongoing self-taught skill development
in ASP.NET. Meaning, the later a feature is implemented, the more sophisticated it becomes than the prior ones.

In addition, each user has his/her own profile page. This is done through routing and asp-route-username. This also applies to the Resumes section, where each type of 
resume has its own page. 

My future goal for this project is to complete the implementation of the Blogs page and perhaps other pages that allow the site's users to interact with me and
with each other. Later down the road, I wish to implement features such as user account settings, notifications, chat, etc. However, at the moment, I will note that I 
plan on studying Angular, .NET API, and SQL (with relational algebra) for now, so I admit that this project will be currently on the backburner for the most part.

This site is deployed on Microsoft Azure Cloud service and it is linked to an Azure SQL server and database.
