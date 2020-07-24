CREATE TABLE Users(
id INT NOT NULL AUTO_INCREMENT,
email VARCHAR(100) NOT NULL,
username VARCHAR(30) NOT NULL,
user_password BLOB NOT NULL,
register_date VARCHAR(100) NOT NULL, 
PRIMARY KEY(id)
);

CREATE TABLE Messages(
id INT NOT NULL AUTO_INCREMENT,
sender_id INT NOT NULL,
receiver_id INT NOT NULL,
send_date VARCHAR(100) NOT NULL,
message VARCHAR(100) NOT NULL,
seen BOOL NOT NULL ,
PRIMARY KEY(id),
CONSTRAINT FK_SenderId_User FOREIGN KEY(sender_id) REFERENCES Users(id) ON DELETE CASCADE,
CONSTRAINT FK_ReceiverId_User FOREIGN KEY(receiver_id) REFERENCES Users(id) ON DELETE CASCADE
);
