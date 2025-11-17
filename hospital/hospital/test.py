import pyodbc

conn = pyodbc.connect(
    r'DRIVER={ODBC Driver 17 for SQL Server};'
    r'SERVER=DATA\MSSQL2025;'
    r'DATABASE=HospitalDB;'
    r'UID=sa;PWD=Admin2025!'
)

cursor = conn.cursor()
cursor.execute("SELECT 1")
print(cursor.fetchone())
