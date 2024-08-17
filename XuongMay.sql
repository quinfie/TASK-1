create database XuongMay
use XuongMay
CREATE TABLE Factory (
    factory_id INT IDENTITY(1,1) PRIMARY KEY,  
    name_factory NVARCHAR(255) NOT NULL,        
    place_factory NVARCHAR(MAX) NOT NULL,       
    dob_factory DATETIME NOT NULL              
);
GO
CREATE TABLE Employee (
    employee_id INT PRIMARY KEY IDENTITY,
    full_name VARCHAR(100),
    position VARCHAR(50),
    department VARCHAR(50),
    hire_date DATE
);
GO
CREATE TABLE Account (
    account_id INT PRIMARY KEY IDENTITY,
    username NVARCHAR(100) UNIQUE,
    pass_word NVARCHAR(50) NOT NULL,
    role_employee INT DEFAULT 0,
    employeeid INT UNIQUE NOT NULL,
    FOREIGN KEY ( employeeid ) REFERENCES Employee( employee_id )
);
GO
CREATE TABLE Category (
    category_id INT PRIMARY KEY IDENTITY,
    category_name NVARCHAR(255) NOT NULL,
    category_description NVARCHAR(MAX)
);
GO
CREATE TABLE Product (
    product_id INT PRIMARY KEY IDENTITY,
    product_name NVARCHAR(255) NOT NULL,
    category_id INT NOT NULL,
    product_size NVARCHAR(255) NOT NULL,
    product_color NVARCHAR(255) NOT NULL,
    product_price DECIMAL(10, 2) NOT NULL,
    product_quantity INT NOT NULL,
    product_description NVARCHAR(MAX),
    product_image_url NVARCHAR(255),
    FOREIGN KEY (category_id) REFERENCES Category(category_id)
);
GO
CREATE TABLE Order_product (
    order_id INT PRIMARY KEY IDENTITY,
    order_date DATETIME NOT NULL,
    order_status NVARCHAR(255) NOT NULL,
    order_total_price DECIMAL(10, 2) NOT NULL,
    order_payment_method NVARCHAR(255) NOT NULL,
    order_shipping_address NVARCHAR(MAX) NOT NULL,
	employee_id INT NOT NULL,
	FOREIGN KEY (employee_id) REFERENCES Employee(employee_id)
);
GO
CREATE TABLE Order_detail (
    order_detail_id INT PRIMARY KEY IDENTITY,
    order_id INT NOT NULL,
    product_id INT NOT NULL,
    order_detail_quantity INT NOT NULL,
    order_detail_price DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (order_id) REFERENCES Order_product(order_id),
    FOREIGN KEY (product_id) REFERENCES Product(product_id)
);
GO
select * from Employee
select * from Account
INSERT INTO Employee (full_name, position, department, hire_date)
VALUES ('Nguyễn Hoàng Lan', 'Quản lý sản xuất', 'Sản xuất', '2023-03-10'),
       ('Trần Ngọc Nhung', 'Kỹ sư điều khiển', 'Sản xuất', '2023-01-20'),
       ('Phạm Thế Anh', 'Nhân viên vận hành', 'Sản xuất', '2023-05-05');

INSERT INTO Account (username, pass_word, role_employee, employeeid)
VALUES ('admin', 'admin1234', 1, 1),
       ('user1', 'an_toan456', 0, 2),
       ('user2', 'passwordxyz', 0, 3);
