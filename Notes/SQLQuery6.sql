SELECT 
    value  
FROM 
    STRING_SPLIT('red,green,,blue', ',');


SELECT 
    value  
FROM 
    STRING_SPLIT('red,green,,blue', ',')
WHERE	
    TRIM(value) <> '';

