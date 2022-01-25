USE rest_with_asp_net_udemy;
CREATE TABLE Company(
	id INT NOT NULL AUTO_INCREMENT,
    stock_name VARCHAR(200) NOT NULL,
    stock_sector VARCHAR(125) NOT NULL,
    ein VARCHAR(20) NOT NULL,
	address VARCHAR(150) NOT NULL,
    CONSTRAINT PK_Company PRIMARY KEY (id)
);