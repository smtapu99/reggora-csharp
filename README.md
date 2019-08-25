# Reggora

## Welcome to `Reggora` api!
### `Reggora C# library` works for `Lender` and `Vendor` APIs supported by [Reggora](https://sandbox.reggora.io/).

## Dependencies
- NuGet (5.2.0)
- NuGet Packages
 
  - MimeMapping v1.0.1.14
  - Newtonsoft.Json v12.0.2
  - RestSharp v106.6.10
  - RestSharp.Newtonsoft.Json v1.5.1
  - Syroot.Windows.IO.KnownFolders v1.2.1
- Microsoft.NETCore.App (2.2.0)

## Building and importing Library 
 - You can get library by building `Reggora.Api`
 - Once the building is done, you can see the library `Reggora.Api.dll` in `Reggora.Api\bin\Release\netcoreapp2.2` directory.
 - You can import this library from adding `Reference`.

## Usage for Lender API

- Initializing Library
    
    ```c#
    private Lender lender = new Lender(integrationToken);
    lender.Authenticate(lenderUserName, lenderPassword); 
    ```
- Make a Request
    
    - Loans
    
        - Get all Loans
            [View detail](https://sandbox.reggora.io/#get-all-loans)
            ```
                uint Offset = 0;
                uint Limit = 0;
                string ordering = "-created";
                string loanOfficer = null;
          
                List<Loan> loans = lender.Loans.All(Offset, limit, ordering, loanOfficer);
            ```
			Response: List of `Loan`

        - Get a Loan
            [View detail](https://sandbox.reggora.io/#get-loan)
            ```
                Loan loan = lender.Loans.Get(string loanId);
            ```
        
        - Delete a Loan
            [View detail](https://sandbox.reggora.io/#delete-loan)
            ```
                string response = lender.Loans.Delete(string loanId);
            ```
            Response: "Loan deleted."

        - Create a Loan
            [View detail](https://sandbox.reggora.io/#create-a-loan)
            ```
                Loan loan = new Loan()
                            {
                                Number = "1",
                                Type = "FHA",
                                Due = DateTime.Now.AddYears(1),
                                PropertyAddress = "100 Mass Ave",
                                PropertyCity = "Boston",
                                PropertyState = "MA",
                                PropertyZip = "02192",
                                CaseNumber = "10029MA",
                                AppraisalType = "Refinance"
                            };
                string response = lender.Loans.Create(loan);
            ```
			Resposne: Id of created Loan

        - Edit a Loan
            [View detail](https://sandbox.reggora.io/#edit-a-loan)
            ```
                loan.Number = "newLoanNumber";
                string response = lender.Loans.Edit(loan);
            ```
			Resposne: Id of updated Loan
      
    - Orders
    
        - Get All Orders
            [View detail](https://sandbox.reggora.io/#get-all-orders)
            ```
                uint Offset = 0;
                uint Limit = 0;
                string ordering = "-created";
                string loanOfficer = null;
                string filters = "";
          
                List<Order> orders = lender.Orders.All(Offset, limit, ordering, loanOfficer);
            ```
			Response: List of `Order`
            
        - Get an Order
            [View detail](https://sandbox.reggora.io/#get-order)
            ```
                Order order = lender.Orders.Get(string orderId);
            ```
          
        - Cancel Order
            [View detail](https://sandbox.reggora.io/#cancel-order)
            ```
                string response = lender.Orders.Cancel(string orderId);
            ```
            Response: "Order has been canceled."

        - Create an Order
            [View detail](https://sandbox.reggora.io/#create-an-order)
            ```
                ** AllocationMode: Automatic, Manual **
                ** PriorityType: Normal, Rush **
          
                Order order = new Order()
                            {
                                Allocation = Order.AllocationMode.Automatic,
                                Loan = loanId,
                                Priority = Order.PriorityType.Normal,
                                ProductIds = productIds,
                                Due = DateTime.Now.AddYears(1)
                            };
                
                string response = lender.Orders.Create(order);
            ```
			Response: Id of created Order
          
        - Edit an Order
            [View detail](https://sandbox.reggora.io/#edit-an-order)
            ```
				** AllocationMode: Automatic, Manual **
                ** PriorityType: Normal, Rush **

                order.Priority = Order.PriorityType.Rush;
                lender.Orders.Edit(order);
            ```
			Response: Id of updated Order
            
        - Place Order On Hold
            [View detail](https://sandbox.reggora.io/#place-order-on-hold)
            ```
                string response = lender.Orders.OnHold(orderId, reason);
            ```
			Response: "Order has been updated"
          
        - Remove Order Hold
            [View detail](https://sandbox.reggora.io/#remove-order-hold)
            ```
                string response = lender.Orders.RemoveHold(orderId);
            ```
			Response: "Order has been updated"
          
    - eVault
    
        - Get eVault by ID
            [View detail](https://sandbox.reggora.io/#get-evault-by-id)
            ```
                Evault evault = lender.Evaults.Get(evaultId);
            ```
        
        - Get Document
            [View detail](https://sandbox.reggora.io/#get-document)
            ```
                lender.Evaults.GetDocument(evaultId, documentId);
            ```
			Response: File object of document
          
        - Upload Document
            [View detail](https://sandbox.reggora.io/#upload-document)
            ```
                string evaultId = "5d4d06d6d28c2600109499c5";
                string documentFilePath = "F:\document.pdf";
                
                string response = lender.Evaults.UploadDocument(evaultId, documentFilePath);
            ```
			Response: Id of uploaded document
        
        - Upload P&S
            [View detail](https://sandbox.reggora.io/#upload-p-amp-s)
            ```
                string orderId = "5d5bc544586cbb000f5e171f";
                string documentFilePath = "F:\document.pdf";
                
                string response = lender.Evaults.UploadDocument(evaultId, documentFilePath);
            ```  
			Response: Id of uploaded P&S document
          
        - Delete Document
            [View detail](https://sandbox.reggora.io/#delete-document)
            ```
                string response = lender.Evaults.DeleteDocument(evaultId, documentId);
            ```  
			Response: "Your document has been deleted"
         
	- Products
			
		- Get All Products
			[View detail](https://sandbox.reggora.io/#get-all-products)
			```
				List<Product> products = lender.Products.All();
			```
			Response: List of `Product`

		- Get a Product
			[View detail](https://sandbox.reggora.io/#get-product)
			```
				Product product = lender.Products.Get(productId);
			```

		- Delete Product
			[View detail](https://sandbox.reggora.io/#delete-product)
			```
				string response = lender.Products.Delete(productId);
			```
			Response: "Your product has been deleted"

		- Create a Product
			[View detail](https://sandbox.reggora.io/#create-a-product)
			```
				** InspectionType: Interior, Exterior **

				Product product = new Product()
								{
									ProductName = "Full Appraisal",
									Amount = 100.00f,
									InspectionType = Product.Inspection.Interior,
									RequestForms = "1004MC, BPO"
								};

				string response = lender.Products.Create(product);
			```
			Response: Id of created product
			
		- Edit a Product
			[View detail](https://sandbox.reggora.io/#edit-a-product)
			```
				product.ProductName = newProductName;
				string response = lender.Products.Edit(product);
			```
			Response: Id of updated product

	- Submissions
		
		- Get All Submissions
			[View detail](https://sandbox.reggora.io/#get-all-submissions)
			```
				string orderId = "5d5bc544586cbb000f5e171f";
				List<Submission> submissions = lender.Orders.Submissions(orderId);
			```
			Response: List of `Submission`

		- Download Submission Document
			[View detail](https://sandbox.reggora.io/#download-submission-document)
			```
				** reportType: "pdf_report", "xml_report", "invoice"
				string orderId = "5d5bc544586cbb000f5e171f";
				uint version = 1;
				string reportType = "pdf_report";

				string downloadPath = null; // If downloadPath is `null`, document will be download `Downloads` path by default

				lender.Orders.DownloadSubmissionDoc(orderId, version, reportType, downloadPath);
			```

	- Users
		
		- Get All Users
			[View details](https://sandbox.reggora.io/#get-all-users)
			```
				List<User> users = lender.Users.All();
			```
			Response: List of `User`

		- Get User By ID
			[View detail](https://sandbox.reggora.io/#get-user-by-id)
			```
				User user = lender.Users.Get(expectedId);
			```

		- Invite User
			[View detail](https://sandbox.reggora.io/#invite-user)
			```
				User user = new User()
							{
								Email = "user@email.com",
								PhoneNumber = "12345678",
								FirstName = "Fake",
								LastName = "Person",
								Role = "Admin"
							};

				string response = lender.Users.Invite(user);
			```
			Response: "Your invite has been sent"

		- Create User
			[View detail](https://sandbox.reggora.io/#create-user)
			```
				User user = new User()
							{
								Email = "user@email.com",
								PhoneNumber = "12345678",
								FirstName = "Fake",
								LastName = "Person",
								NmlsId = "MA",
								Role = "Admin"
							};

				string response = lender.Users.Create(user);
			```
			Response: Id of created user

		- Edit User
			[View detail](https://sandbox.reggora.io/#edit-user)
			```
				string response = lender.Users.Edit(userId);
			```
			Response: Id of updated user

		- Delete User
			[View detail](https://sandbox.reggora.io/#delete-user)
			```
				string response = lender.Users.Delete(deleteId);
			```
			Response: "Your user has been deleted"

	- Vendors
		
		- Get All Vendors
			[View detail](https://sandbox.reggora.io/#get-all-vendors)
			```
				var vendors = lender.Vendors.All();
			```

		- Get Vendors By Zone
			[View detail](https://sandbox.reggora.io/#get-vendors-by-zone)
			```
				List<string> zones = new List<string> { "02806", "02807", "03102" };
				uint offset = 0;
				uint limit = 0;
				string ordering = "-created";
				List<Vendr> vendors = lender.Vendors.GetByZone(zones, offset, limit, ordering);
			```
			Response: List of `Vendr`

		- Get Vendors By Branch
			[View detail](https://sandbox.reggora.io/#get-vendors-by-branch)
			```
				List<Vendr> vendors = lender.Vendors.GetByBranch(branchId);
			```
			Response: List of `Vendr`

		- Get Vendor By ID
			[View detail](https://sandbox.reggora.io/#get-vendor-by-id)
			```
				Vendr vendor = lender.Vendors.Get(vendorId);
			```

		- Add Vendor
			[View detail](https://sandbox.reggora.io/#add-vendor)
			```
				Vendr vendor = new Vendr()
							{
								FirmName = "Appraisal Firm",
								Email = "vendor@email.com",
								Phone = "12345678",
								FirstName = "Fake",
								LastName = "Vendor"
							};

				string response = lender.Vendors.Create(vendor);
			```
			Response: Id of added vendor

		- Edit Vendor
			[View detail](https://sandbox.reggora.io/#edit-vendor)
			```
				vendor.Phone = newPhoneNumber;

				string response = lender.Vendors.Edit(vendor);
			```
			Response: Id of updated vendor

		- Delete Vendor
			[View detali](https://sandbox.reggora.io/#delete-vendor)
			```
				string resposne = lender.Vendors.Delete(deleteId);
			```
			Resposne: "Your vendor has been removed"

	- Schedule & Payment App
		
		- Send Payment App
			[View detail](https://sandbox.reggora.io/#send-payment-app)
			```
				** UsrType: Manual, Consumer **
				** PaymenType: Manual, Stripe ** 

				PaymentApp app = new PaymentApp()
								{
									ConsumerEmail = "user@email.com",
									OrderId = "5c33c6b1681f110034effc72",
									UsrType = PaymentApp.UserType.Manual,
									PaymenType = PaymentApp.PaymentType.Manual,
									Amount = 100.00f,
									FirstName = "Fake",
									LastName = "Person",
									Paid = false
								};

				string rsponse = lender.Apps.SendPaymentApp(app);
			```
			Response = "Payment app sent."

		- Send Scheduling App
			[View detail](https://sandbox.reggora.io/#send-scheduling-app)
			```
				List<string> consumerEmails = new List<string> { "example@consumer.com"};
				string orderId = "5c33c6b1681f110034effc72";

				string response = lender.Apps.SendSchedulingApp(consumerEmails, orderId);
			```
			Response: "Scheduling app sent."
		
		- Consumer Application Link
			[View detail](Consumer Application Link)
			```
				** linkType: Payment, Scheduling, Both ** 

				string orderId = "5c33c6b1681f110034effc72";
				string consumerId = "5c33c716681f110034effc73";
				PaymentApp.LinkType linkType = PaymentApp.LinkType.Payment;

				string response = lender.Apps.ConsumerAppLink(orderId, consumerId, linkType);
			```
			Response: "https://devconnect.reggora.com/schedule/.eJw1yjEOgCAMBdC7dJYE6i9WL2OAQuKgJBon492dfPN7qJ9Wz3UzWkiMUZoWnYMV-DFEFuSJaaDSj-ve_xgbGqvCcbLqoCZOq49OMhQhRUMN9H7l7hoK.B8-lmAvVwbOAqLz_-uzL8JIGXgA?iframe=true&override=payment"


				
