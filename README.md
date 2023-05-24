Overview function:

  1. Client:
  
    - Register and login account.
    - View posts, news or contact address.
    - Search products and Filter them by price, category.
    - View the products information and add them to cart.
    - Intergrated VNpay for quick payment.
    - Get the email about Order info after checkout.
    
  2. Admin:
  
    - CRUD: products, role, account, news, posts,...
    - Common setting: SEO stuffs, logo, url to the website,...
    - Sales Revenue 
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
How to run:

  1. Open CMD at the location you want to run the project
  2. Type "git clone https://github.com/thinh12112001/banhangonline.git"
  3. Then open Visual Studio and open the foler you just clone.
  4. Open SQL Server and choose the Server you want to connect.
  5. Copy the name of that server.
  
  ![image](https://user-images.githubusercontent.com/74391992/236594329-fe8d9054-f097-442a-a04f-9f00fed9086c.png)
  
  6. Return to the location you just clone the project and open file "Web.config".
  7. Find "connectionStrings", inside that config the line:
  
"add name="DefaultConnection" providerName="System.Data.SqlClient" connectionString="Data Source=YOUR-SEVER-NAME;Initial Catalog=WebsiteBanHangOnline;Integrated Security=True;MultipleActiveResultSets=True" "

  8. In Visual Studio, choose Tools ==> Nuget Packet Manager ==> Package Manger Console ==> Type "Update-database -Verbose" and enter.
  9. Enjoy the website.
