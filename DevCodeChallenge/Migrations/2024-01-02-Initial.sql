CREATE TABLE purchases (
    id INT AUTO_INCREMENT,
    quantity INT,
    total_cost DECIMAL(10, 2),
    date DATE,
    PRIMARY KEY (id)
);

DELIMITER //
CREATE PROCEDURE InsertRows()
BEGIN
    DECLARE i INT DEFAULT 0;
    WHILE i < 50 DO
        INSERT INTO purchases (quantity, total_cost, date) 
        VALUES (FLOOR(1 + RAND() * 10), FLOOR(10 + RAND() * 2000), DATE_ADD('2024-01-01', INTERVAL i DAY));
        SET i = i + 1;
    END WHILE;
END //
DELIMITER ;

CALL InsertRows();

DROP PROCEDURE InsertRows;
