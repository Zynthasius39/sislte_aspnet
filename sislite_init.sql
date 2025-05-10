-- ================================================================
-- PostgreSQL Schema Definition
-- File: sislte.sql
-- ================================================================

CREATE TABLE Student
(
    student_id      SERIAL PRIMARY KEY,
    password        CHAR(64) NOT NULL,
    email           TEXT     NOT NULL UNIQUE,
    register_date   TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    last_login_date TIMESTAMP,
    last_login_ip   INET,
    advisor         TEXT,
    prefs           JSONB,
    gpa             NUMERIC(4, 2),
    tatc            INT,
    tacc            INT,
    sac             INT
);

CREATE INDEX idx_student_email ON Student (email);

CREATE TABLE Announce
(
    announce_id SERIAL PRIMARY KEY,
    title       TEXT      NOT NULL,
    message     TEXT      NOT NULL,
    date        TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Course
(
    course_id SERIAL PRIMARY KEY,
    code      VARCHAR(20) NOT NULL UNIQUE,
    name      TEXT        NOT NULL,
    theory    INT         NOT NULL,
    ects      INT         NOT NULL
);

CREATE TABLE Attendance
(
    att_id     SERIAL PRIMARY KEY,
    student_id INT     NOT NULL,
    course_id  INT     NOT NULL,
    date       DATE    NOT NULL,
    presence   BOOLEAN NOT NULL,
    FOREIGN KEY (student_id) REFERENCES Student (student_id) ON DELETE CASCADE,
    FOREIGN KEY (course_id) REFERENCES Course (course_id) ON DELETE CASCADE
);

CREATE INDEX idx_attendance_student_id ON Attendance (student_id);
CREATE INDEX idx_attendance_course_id ON Attendance (course_id);

CREATE TABLE Program
(
    program_id SERIAL PRIMARY KEY,
    code       VARCHAR(20) NOT NULL UNIQUE,
    name       TEXT        NOT NULL,
    lang       VARCHAR(10) NOT NULL
);

CREATE TABLE Grade
(
    grade_id   SERIAL PRIMARY KEY,
    student_id INT NOT NULL,
    course_id  INT NOT NULL,
    act1       INT CHECK (act1 BETWEEN 0 AND 15),
    act2       INT CHECK (act2 BETWEEN 0 AND 15),
    att        INT CHECK (att BETWEEN 0 AND 10),
    iw         INT CHECK (iw BETWEEN 0 AND 10),
    final      INT CHECK (final BETWEEN 0 AND 50),
    sum        INT GENERATED ALWAYS AS (
        COALESCE(act1, 0) +
        COALESCE(act2, 0) +
        COALESCE(att, 0) +
        COALESCE(iw, 0) +
        COALESCE(final, 0)
        ) STORED,
    FOREIGN KEY (student_id) REFERENCES Student (student_id) ON DELETE CASCADE,
    FOREIGN KEY (course_id) REFERENCES Course (course_id) ON DELETE CASCADE,
    UNIQUE (student_id, course_id)
);

CREATE INDEX idx_grade_student_id ON Grade (student_id);
CREATE INDEX idx_grade_course_id ON Grade (course_id);

CREATE TABLE Semesters
(
    semester_id SERIAL PRIMARY KEY,
    spa         NUMERIC(4, 2),
    start_date  DATE NOT NULL,
    end_date    DATE NOT NULL
);

CREATE TABLE SemesterStudents
(
    semester_id INT NOT NULL,
    student_id  INT NOT NULL,
    PRIMARY KEY (semester_id, student_id),
    FOREIGN KEY (semester_id) REFERENCES Semesters (semester_id) ON DELETE CASCADE,
    FOREIGN KEY (student_id) REFERENCES Student (student_id) ON DELETE CASCADE
);

CREATE TABLE SemesterCourses
(
    semester_id INT NOT NULL,
    course_id   INT NOT NULL,
    PRIMARY KEY (semester_id, course_id),
    FOREIGN KEY (semester_id) REFERENCES Semesters (semester_id) ON DELETE CASCADE,
    FOREIGN KEY (course_id) REFERENCES Course (course_id) ON DELETE CASCADE
);

