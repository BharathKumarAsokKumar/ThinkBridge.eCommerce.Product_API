Feature: Product
	Product based features

@AddnewProduct
Scenario: Add new Product
	Given the user has  new product
	When the user adds new product
	| Id | Name | Description | Price |
	| 1  | Toy  | Baby Toys   | 100   |
	| 2  | Groceries  | Toor Dhal   | 200   |
	| 3  | Vegetable  | Ladies Finger   | 300   |
	| 4  | Fruit  | Apple   | 400   |
	Then the result should be 1


	@GetAllProduct
	Scenario: Get All Products
	Given the user has wish to see all products
	When the user search all product
	Then the result should be 
	| Id | Name | Description | Price |
	| 1  | Toy  | Baby Toys   | 100   |
	| 2  | Groceries  | Toor Dhal   | 200   |
	| 3  | Vegetable  | Ladies Finger   | 300   |
	| 4  | Fruit  | Apple   | 400   |

	@GetProductbyName
	Scenario: Get Product by Name
	Given the user has product Name
	When the user search a product
	 | Id | Name |
	 | 1  | Toy  |
	Then the result should be 
	| Id | Name | Description | Price |
	| 1  | Toy  | Baby Toys   | 100   |

	@UpdateProductbyID
	Scenario: Update Product by ID
	Given the user has product Name to be updated
	When the user Updates a product
	 | Id | Name      |
	 | 2  | Groceries |  
	Then the successfull updates represents result as 1 

	@RemoveProductbyID
	Scenario: Remove Product by ID
	Given the user has product Name to be removed
	When the user removes a product
	 | Id | Name      |
	 | 3  | Vegetable |  
	Then the successfull delete of product represents result as 1 