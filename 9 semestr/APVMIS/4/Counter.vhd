----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date:    19:24:07 10/05/2014 
-- Design Name: 
-- Module Name:    Counter - Behavioral 
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
library UNISIM;
use UNISIM.VComponents.all;

entity Counter is
	 Port ( G : in  STD_LOGIC;
           R : in  STD_LOGIC;
           CCLR : in  STD_LOGIC;
           UP : in  STD_LOGIC;
           LOAD : in  STD_LOGIC;
           ENP : in  STD_LOGIC;
           ENT : in  STD_LOGIC;
           CLOCK : in  STD_LOGIC;
			  CLOCK_N : in  STD_LOGIC;
           A, B, C, D : in  STD_LOGIC;
           Qa, Qb, Qc, Qd : out  STD_LOGIC;
           RCO : out  STD_LOGIC);
end Counter;

architecture Behavioral of Counter is
	component main is
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
	end component main;
	
	component FrequencyDivider is
		Port ( CLOCK_IN : in  STD_LOGIC;
				CLOCK_OUT : out  STD_LOGIC);
	end component FrequencyDivider;

	signal CLOCK_TMP, CLOCK_FROM_IBUFDS : STD_LOGIC;
	
begin

	ibufds0: ibufds port map (
		I => CLOCK,
		IB => CLOCK_N,
		O => CLOCK_FROM_IBUFDS
	);

	FrequencyDivider0: FrequencyDivider port map (
		CLOCK_IN => CLOCK_FROM_IBUFDS,
		CLOCK_OUT => CLOCK_TMP
	);
	
	main_inst: main port map (
		G => G, 
	   R => R, 
	   RCK => CLOCK_TMP, 
	   CCLR => CCLR, 
	   UP => UP, 
	   LOAD => LOAD, 
	   ENP => ENP, 
	   ENT => ENT, 
	   CCK => CLOCK_TMP, 
	   A => A,
		B => B, 
		C => C, 
		D => D, 
	   Qa => Qa, 
		Qb => Qb, 
		Qc => Qc, 
		Qd => Qd, 
	   RCO => RCO 
	);

end Behavioral;

