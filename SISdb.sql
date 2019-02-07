CREATE TABLE dbo.Courses (
	CourseID int NOT NULL,
	CourseName nvarchar(max) NULL,
	DepartmentID int NOT NULL
);

ALTER TABLE dbo.Courses ADD CONSTRAINT PK__Courses__C92D7187A351F2AD PRIMARY KEY (CourseID);

-- Add 0 rows for Courses.
CREATE TABLE dbo.Department (
	DepartmentID int NOT NULL,
	DepartmentName nvarchar(max) NULL
);

ALTER TABLE dbo.Department ADD CONSTRAINT PK__Departme__B2079BCDFBC72284 PRIMARY KEY (DepartmentID);

-- Add 0 rows for Department.
CREATE TABLE dbo.Instructor (
	InstructorID int NOT NULL,
	InstructorFirstName nvarchar(max) NULL,
	InstructorLastName nvarchar(max) NULL,
	InstructorPhone nvarchar(max) NULL,
	InstructorHireDepartment nvarchar(max) NULL
);

ALTER TABLE dbo.Instructor ADD CONSTRAINT PK__Instruct__9D010B7B14506047 PRIMARY KEY (InstructorID);

-- Add 0 rows for Instructor.
CREATE TABLE dbo.Registration (
	StudentID int NOT NULL,
	CourseID int NOT NULL,
	TermID int NOT NULL
);

ALTER TABLE dbo.Registration ADD CONSTRAINT PK__Registra__1A16F74F281A3F27 PRIMARY KEY (StudentID, CourseID, TermID);

-- Add 0 rows for Registration.
CREATE TABLE dbo.Student (
	StudentID int NOT NULL,
	StudentFirstName nvarchar(max) NULL,
	StudentLastName nvarchar(max) NULL,
	StudentEnrollment nvarchar(max) NULL,
	StudentPhone nvarchar(max) NULL
);

ALTER TABLE dbo.Student ADD CONSTRAINT PK__Student__32C52A794F25C602 PRIMARY KEY (StudentID);

-- Add 0 rows for Student.
CREATE TABLE dbo.StudyTerm (
	TermID int NOT NULL,
	TermName nvarchar(max) NULL,
	TermStartDate datetime NULL,
	TermEndDate datetime NULL,
	TermYear int NULL,
	TermSeason nvarchar(max) NULL
);

ALTER TABLE dbo.StudyTerm ADD CONSTRAINT PK__StudyTer__410A2E454631A93A PRIMARY KEY (TermID);

-- Add 0 rows for StudyTerm.
CREATE TABLE dbo.TeachingAssignment (
	CourseID int NOT NULL,
	InstructorID int NOT NULL,
	TermID int NOT NULL
);

ALTER TABLE dbo.TeachingAssignment ADD CONSTRAINT PK__Teaching__24BC6B1E82A67F48 PRIMARY KEY (CourseID, InstructorID, TermID);

-- Add 0 rows for TeachingAssignment.
