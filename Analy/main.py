import yfinance as yf
import streamlit as st
from sqlalchemy import create_engine
import pandas as pd

SERVER = 'LAPTOP-97PPLKMR\SQLEXPRESS'
DATABASE = 'TEST'
DRIVER = 'ODBC Driver 17 for SQL Server'
USERNAME = 'sa'
PASSWORD = 'Phuc1707'
DATABASE_CONNECTION = f'mssql://{USERNAME}:{PASSWORD}@{SERVER}/{DATABASE}?driver={DRIVER}'

engine = create_engine(DATABASE_CONNECTION)
connection = engine.connect()

data = pd.read_sql_query('select * from Persons', connection)
data



# comment='''Display the data'''
# host="localhost"
# port = 5432
# database="sqlda"
# user="postgres"

# from sqlalchemy import create_engine
# try:
#     conn = create_engine('postgresql://{}:{}@{}:{}/{}'.format(user,password,host,port,database))
# except (Exception, Error) as error:
#     print("Error while connecting to PostgreSQL", error)

# from sqlalchemy import inspect
# inspector = inspect(conn)
# inspector.get_table_names()

st.write("""
## Simple Stock Price App
Shown are the stock closing price and volume of Google!
""")

# engine_pass = config('DB_TEST')
# e = create_engine(engine_pass)
# connection = e.raw_connection()

# df_comments = pd.read_sql_query('SELECT * FROM Persons', connection)
# st.write(df_comments.head())

# https://towardsdatascience.com/how-to-get-stock-data-using-python-c0de1df17e75
#define the ticker symbol
tickerSymbol = 'GOOGL'
#get data on this ticker
tickerData = yf.Ticker(tickerSymbol)
#get the historical prices for this ticker
tickerDf = tickerData.history(period='1d', start='2010-5-31', end='2020-5-31')
# Open	High	Low	Close	Volume	Dividends	Stock Splits

st.line_chart(tickerDf.Close)
st.line_chart(tickerDf.Volume)