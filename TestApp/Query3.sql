SELECT Name FROM( SELECT TOP 1 DEPARTMENT.Name, sum(SALARY) as sum_salary
from EMPLOYEE join DEPARTMENT on EMPLOYEE.DEPARTMENT_ID = DEPARTMENT.ID
group by DEPARTMENT.Name
order by sum_salary desc) AS Name
