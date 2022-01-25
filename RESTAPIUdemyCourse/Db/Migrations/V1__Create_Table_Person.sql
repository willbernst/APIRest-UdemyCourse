USE rest_with_asp_net_udemy;
CREATE TABLE Person(
	id INT NOT NULL AUTO_INCREMENT,
    first_name VARCHAR(100) NOT NULL,
    last_name VARCHAR(100) NOT NULL,
    age INT(2) NOT NULL,
	address VARCHAR(120) NOT NULL,
    gender VARCHAR(15) NOT NULL,
    CONSTRAINT PK_Person PRIMARY KEY (id)
);