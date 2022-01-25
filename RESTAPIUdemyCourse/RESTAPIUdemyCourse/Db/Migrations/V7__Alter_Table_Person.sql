USE rest_with_asp_net_udemy;
ALTER TABLE Person
	ADD enabled BIT NOT NULL DEFAULT 1
    AFTER gender;