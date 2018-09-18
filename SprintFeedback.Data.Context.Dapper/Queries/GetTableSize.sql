SELECT  table_rows
FROM  information_schema.TABLES
WHERE  TABLE_SCHEMA = @DatabaseName
	AND  TABLE_NAME = @TableName
