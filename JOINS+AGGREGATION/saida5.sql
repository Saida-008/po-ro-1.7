--SELECT f.title, c.name AS category_name
--FROM film f
--JOIN film_category fc ON f.film_id = fc.film_id
--JOIN category c ON fc.category_id = c.category_id
--ORDER BY f.title
--LIMIT 20;
--
--SELECT first_name, last_name, email
--FROM customer
--WHERE email LIKE '%@sakilacustomer.org'
--ORDER BY last_name;
--
--SELECT rating, COUNT(*) AS film_count
--FROM film
--GROUP BY rating
--ORDER BY film_count DESC;
--
--SELECT DISTINCT c.first_name, c.last_name
--FROM customer c
--JOIN rental r        ON c.customer_id = r.customer_id
--JOIN inventory i     ON r.inventory_id = i.inventory_id
--JOIN film f          ON i.film_id = f.film_id
--JOIN film_category fc ON f.film_id = fc.film_id
--JOIN category cat     ON fc.category_id = cat.category_id
--WHERE cat.name = 'Action'
--ORDER BY c.last_name;

SELECT cat.name AS category_name,
       ROUND(SUM(p.amount), 2) AS total_revenue
FROM payment p
JOIN rental r        ON p.rental_id = r.rental_id
JOIN inventory i     ON r.inventory_id = i.inventory_id
JOIN film f          ON i.film_id = f.film_id
JOIN film_category fc ON f.film_id = fc.film_id
JOIN category cat     ON fc.category_id = cat.category_id
GROUP BY cat.name
HAVING SUM(p.amount) > 4000
ORDER BY total_revenue DESC;

