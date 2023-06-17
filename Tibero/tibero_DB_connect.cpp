// DB연결 예제 (tibero_ado.cpp : Defines the entry point for the console application.)
#include <windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <sql.h>
#include <sqlext.h>
/* #include "stdafx.h" */
#define ROWSET_SIZE 20
int main(int argc, char* argv[])
{
	SQLRETURN rc = SQL_SUCCESS;
	SQLUINTEGER len;
	SQLHANDLE henv, hdbc, hstmt;
	SQLCHAR *sql = (SQLCHAR *)"SELECT TO_CHAR(SYSDATE,'YYYYMMDD') FROM DUAL";
	char buf[128];
	/* 커넥션을 위한 메모리 할당 */
	SQLAllocHandle(SQL_HANDLE_ENV, SQL_NULL_HANDLE, &henv);
	SQLSetEnvAttr(henv, SQL_ATTR_ODBC_VERSION, (SQLPOINTER)SQL_OV_ODBC3, 0);
	SQLAllocHandle(SQL_HANDLE_DBC, henv, &hdbc);
	/* Tibero Connect절 */
	rc = SQLConnect(hdbc, (SQLCHAR *)"tibero", SQL_NTS, (SQLCHAR *)"sys", SQL_NTS, (SQLCHAR *)"tibero", SQL_NTS);
	if (rc != SQL_SUCCESS)
	{
	fprintf(stderr, "Connection failed!!!");
	exit(1);
	}
	/* Statements 를 위한 메모리 할당*/
	SQLAllocHandle(SQL_HANDLE_STMT, hdbc, &hstmt);
	printf("Query: %s\n", sql);
	/* 쿼리 수행*/
	rc = SQLExecDirect(hstmt, sql, SQL_NTS);
	if (rc != SQL_SUCCESS)
	{
	fprintf(stderr, "SQLExecDirect failed!!!");
	exit(1);
	}
	/* 결과값 바인딩 처리*/
	SQLBindCol(hstmt, 1, SQL_C_CHAR, (SQLCHAR *)buf, 128, (long *)&len);
	printf("Result: ", buf);
	/* 결과값 패치*/
	while(SQLFetch(hstmt) != SQL_NO_DATA) {
	printf("%s\n", buf);
	}
	/* 핸들 해제 및 접속을 종료 */
	SQLFreeStmt(hstmt, SQL_DROP);
	SQLDisconnect(hdbc);
	SQLFreeConnect(hdbc);
	SQLFreeEnv(henv);
	return 0;
}