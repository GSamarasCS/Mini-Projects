CREATE OR REPLACE FUNCTION reserv_per_cat ()
 RETURNS TABLE (
 categories varchar(9),
 res integer
 ) AS $$
 DECLARE
 rec_res RECORD;

reservations CURSOR FOR
	 select category, count(room_number) as nbofrooms
	 from Rooms_Reserved natural join Rooms
	 group by category;

BEGIN
	OPEN reservations;
	LOOP
		FETCH reservations INTO rec_res;
		EXIT WHEN NOT FOUND;
		categories := rec_res.category;
		res := rec_res.nbofrooms;
		RETURN NEXT;
	END LOOP;
	CLOSE reservations;
END;$$
LANGUAGE plpgsql;

-- Εμφάνιση αποτελεσμάτων:
select * from reserv_per_cat();
