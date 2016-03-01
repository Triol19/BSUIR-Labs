----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date:    17:48:33 10/04/2015 
-- Design Name: 
-- Module Name:    main - Behavioral 
-- Project Name: 
-- Target Devices: 
-- Tool versions: 
-- Description: 
--
-- Dependencies: 
--
-- Revision: 
-- Revision 0.01 - File Created
-- Additional Comments: 
--
----------------------------------------------------------------------------------
library IEEE;
use IEEE.STD_LOGIC_1164.ALL;

-- Uncomment the following library declaration if using
-- arithmetic functions with Signed or Unsigned values
--use IEEE.NUMERIC_STD.ALL;

-- Uncomment the following library declaration if instantiating
-- any Xilinx primitives in this code.
--library UNISIM;
--use UNISIM.VComponents.all;

entity main is
    Port ( G : in  STD_LOGIC;
           R : in  STD_LOGIC;
           RCK : in  STD_LOGIC;
           CCLR : in  STD_LOGIC;
           UP : in  STD_LOGIC;
           LOAD : in  STD_LOGIC;
           ENP : in  STD_LOGIC;
           ENT : in  STD_LOGIC;
           CCK : in  STD_LOGIC;
           A, B, C, D : in  STD_LOGIC;
           Qa, Qb, Qc, Qd : out  STD_LOGIC;
           RCO : out  STD_LOGIC);
end main;

architecture Behavioral of main is
	component dff is 
		Port ( S : in  STD_LOGIC;
				 R : in  STD_LOGIC;
				 D : in  STD_LOGIC;
				 C : in  STD_LOGIC;
				 Q : out  STD_LOGIC;
				 NQ : out  STD_LOGIC);
	end component;
	
	signal notR, notUp: std_logic;
	signal andNor_1, andNor_2, andNor_3, andNor_4, 
			 andNor_5, andNor_6, andNor_7, andNor_8, 
			 andNor_9, andNor_10, andNor_11, andNor_12: std_logic;
	signal dff1_Q, dff1_NQ, dff2_Q, dff2_NQ, 
			 dff3_Q, dff3_NQ, dff4_Q, dff4_NQ: std_logic;
	signal dff5_NQ, dff6_NQ, dff7_NQ, dff8_NQ: std_logic;
	signal fromA, fromB, fromC, fromD: std_logic;
	signal tripleNotAnd: std_logic;
	signal forAndNor_5, forAndNor_6, forAndNor_7, forAndNor_8: std_logic;

begin
	notR <= not R;
	notUp <= not UP;
	
	fromA <= not (A or LOAD);
	fromB <= not (B or LOAD);
	fromC <= not (C or LOAD);
	fromD <= not (D or LOAD);
	
	tripleNotAnd <= (LOAD and (not ENP) and (not ENT));
	
	forAndNor_5 <= not tripleNotAnd;
	forAndNor_6 <= ((not tripleNotAnd) or (not andNor_1));
	forAndNor_7 <= ((not tripleNotAnd) or (not andNor_1) or (not andNor_2));
	forAndNor_8 <= ((not tripleNotAnd) or (not andNor_1) or (not andNor_2) or (not andNor_3));
	
	--------------------------------------------------------
	
	andNor_1 <= not ((notUp and dff1_Q) or (UP and dff1_NQ));
	andNor_2 <= not ((notUp and dff2_Q) or (UP and dff2_NQ));
	andNor_3 <= not ((notUp and dff3_Q) or (UP and dff3_NQ));
	andNor_4 <= not ((notUp and dff4_Q) or (UP and dff4_NQ));
	
	RCO <= not (andNor_1 and andNor_2 and andNor_3 and andNor_4 and (not ENT));
	
	andNor_5 <= not ((dff1_Q and tripleNotAnd) or (forAndNor_5 and LOAD and dff1_NQ) or fromA);
	andNor_6 <= not ((dff2_Q and tripleNotAnd and andNor_1) or (forAndNor_6 and LOAD and dff2_NQ) or fromB);
	andNor_7 <= not ((dff3_Q and tripleNotAnd and andNor_1 and andNor_2) or (forAndNor_7 and LOAD and dff3_NQ) or fromC);
	andNor_8 <= not ((dff4_Q and tripleNotAnd and andNor_1 and andNor_2 and andNor_3) or (forAndNor_8 and LOAD and dff4_NQ) or fromD);
	
	dff1 : dff
	port map(
		D => andNor_5,
		C => CCK,
		R => CCLR,
		
		S => '1',
	
		Q => dff1_Q,
		NQ => dff1_NQ
	);
	
	dff2 : dff
	port map(
		D => andNor_6,
		C => CCK,
		R => CCLR,
		
		S => '1',
	
		Q => dff2_Q,
		NQ => dff2_NQ
	);
	
	dff3 : dff
	port map(
		D => andNor_7,
		C => CCK,
		R => CCLR,
		
		S => '1',
	
		Q => dff3_Q,
		NQ => dff3_NQ
	);
	
	dff4 : dff
	port map(
		D => andNor_8,
		C => CCK,
		R => CCLR,
		
		S => '1',
	
		Q => dff4_Q,
		NQ => dff4_NQ
	);
	
	dff5 : dff
	port map(
		D => dff1_Q,
		C => RCK,
		
		R => '1',
		S => '1',
	
		NQ => dff5_NQ
	);
	
	dff6 : dff
	port map(
		D => dff2_Q,
		C => RCK,
		
		R => '1',
		S => '1',
	
		NQ => dff6_NQ
	);
	
	dff7 : dff
	port map(
		D => dff3_Q,
		C => RCK,
		
		R => '1',
		S => '1',
	
		NQ => dff7_NQ
	);
	
	dff8 : dff
	port map(
		D => dff4_Q,
		C => RCK,
		
		R => '1',
		S => '1',
	
		NQ => dff8_NQ
	);
	
	andNor_9 <= not ((R and dff5_NQ) or (notR and dff1_NQ));
	andNor_10 <= not ((R and dff6_NQ) or (notR and dff2_NQ));
	andNor_11 <= not ((R and dff7_NQ) or (notR and dff3_NQ));
	andNor_12 <= not ((R and dff8_NQ) or (notR and dff4_NQ));
	
	with (G) select
		Qa <= andNor_9 when '0',
				'Z' when others;
	
		
	with (G) select
	Qb <= andNor_10 when '0',
	      'Z' when others;
			
	with (G) select
	Qc <= andNor_11 when '0',
	      'Z' when others;
			
	with (G) select
	Qd <= andNor_12 when '0',
	      'Z' when others;
	

end Behavioral;

