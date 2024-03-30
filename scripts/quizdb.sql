--
-- PostgreSQL database dump
--

-- Dumped from database version 13.3 (Debian 13.3-1.pgdg100+1)
-- Dumped by pg_dump version 13.3

-- Started on 2024-03-30 15:24:48 UTC

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 201 (class 1259 OID 33264)
-- Name: questions_table; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.questions_table (
    id uuid NOT NULL,
    test_id uuid NOT NULL,
    question character varying(500) NOT NULL,
    answers json NOT NULL
);


ALTER TABLE public.questions_table OWNER TO postgres;

--
-- TOC entry 202 (class 1259 OID 33272)
-- Name: test_results_table; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.test_results_table (
    id uuid NOT NULL,
    test_id uuid NOT NULL,
    email character varying(100) NOT NULL,
    answers json NOT NULL
);


ALTER TABLE public.test_results_table OWNER TO postgres;

--
-- TOC entry 200 (class 1259 OID 33256)
-- Name: tests_table; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tests_table (
    id uuid NOT NULL,
    name character varying(150) NOT NULL,
    description character varying(1000) NOT NULL
);


ALTER TABLE public.tests_table OWNER TO postgres;

--
-- TOC entry 2951 (class 0 OID 33264)
-- Dependencies: 201
-- Data for Name: questions_table; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.questions_table (id, test_id, question, answers) FROM stdin;
\.


--
-- TOC entry 2952 (class 0 OID 33272)
-- Dependencies: 202
-- Data for Name: test_results_table; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.test_results_table (id, test_id, email, answers) FROM stdin;
\.


--
-- TOC entry 2950 (class 0 OID 33256)
-- Dependencies: 200
-- Data for Name: tests_table; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tests_table (id, name, description) FROM stdin;
\.


--
-- TOC entry 2813 (class 2606 OID 33263)
-- Name: tests_table TestsTable_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tests_table
    ADD CONSTRAINT "TestsTable_pkey" PRIMARY KEY (id);


--
-- TOC entry 2815 (class 2606 OID 33271)
-- Name: questions_table questions_table_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.questions_table
    ADD CONSTRAINT questions_table_pkey PRIMARY KEY (id);


--
-- TOC entry 2817 (class 2606 OID 33279)
-- Name: test_results_table test_results_table_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.test_results_table
    ADD CONSTRAINT test_results_table_pkey PRIMARY KEY (id);


--
-- TOC entry 2818 (class 2606 OID 33280)
-- Name: questions_table questions_table_test_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.questions_table
    ADD CONSTRAINT questions_table_test_id_fkey FOREIGN KEY (test_id) REFERENCES public.tests_table(id) NOT VALID;


--
-- TOC entry 2819 (class 2606 OID 33285)
-- Name: test_results_table test_results_table_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.test_results_table
    ADD CONSTRAINT test_results_table_id_fkey FOREIGN KEY (id) REFERENCES public.tests_table(id) NOT VALID;


-- Completed on 2024-03-30 15:24:48 UTC

--
-- PostgreSQL database dump complete
--

