USE rest_with_asp_net_udemy;
CREATE TABLE User(
	id INT NOT NULL AUTO_INCREMENT,
    user_name VARCHAR(100) NOT NULL,
    password VARCHAR(150) NOT NULL,
	full_name VARCHAR(175) NULL,
    refresh_token VARCHAR(100) NULL,
    refresh_token_expire_time DATETIME NOT NULL,
    CONSTRAINT PK_Person PRIMARY KEY (id),
    UNIQUE (user_name)
);