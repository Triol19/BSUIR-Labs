--------------------------------------------------------------------------------
-- Company: 
-- Engineer:
--
-- Create Date:   17:14:49 09/11/2015
-- Design Name:   
-- Module Name:   C:/Users/lab1/test.vhd
-- Project Name:  lab1
-- Target Device:  
-- Tool versions:  
-- Description:   
-- 
-- VHDL Test Bench Created by ISE for module: mux
-- 
-- Dependencies:
-- 
-- Revision:
-- Revision 0.01 - File Created
-- Additional Comments:
--
-- Notes: 
-- This testbench has been automatically generated using types std_logic and
-- std_logic_vector for the ports of the unit under test.  Xilinx recommends
-- that these types always be used for the top-level I/O of a design in order
-- to guarantee that the testbench will bind correctly to the post-implementation 
-- simulation model.
--------------------------------------------------------------------------------
LIBRARY ieee;
USE ieee.std_logic_1164.ALL;
USE ieee.numeric_std.ALL;
 
-- Uncomment the following library declaration if using
-- arithmetic functions with Signed or Unsigned values
--USE ieee.numeric_std.ALL;
 
ENTITY test IS
END test;
 
ARCHITECTURE behavior OF test IS 
 
    -- Component Declaration for the Unit Under Test (UUT)
 
    COMPONENT mux
    PORT(
         i0 : IN  std_logic;
         i1 : IN  std_logic;
         i2 : IN  std_logic;
         i3 : IN  std_logic;
         i4 : IN  std_logic;
         i5 : IN  std_logic;
         i6 : IN  std_logic;
         i7 : IN  std_logic;
         c0 : IN  std_logic;
         c1 : IN  std_logic;
         c2 : IN  std_logic;
         output : OUT  std_logic
        );
    END COMPONENT;
    

   --Inputs
   signal i0 : std_logic := '0';
   signal i1 : std_logic := '1';
   signal i2 : std_logic := '0';
   signal i3 : std_logic := '1';
   signal i4 : std_logic := '0';
   signal i5 : std_logic := '1';
   signal i6 : std_logic := '0';
   signal i7 : std_logic := '1';
   signal c0 : std_logic := '0';
   signal c1 : std_logic := '0';
   signal c2 : std_logic := '0';

 	--Outputs
   signal output : std_logic;
   -- No clocks detected in port list. Replace <clock> below with 
   -- appropriate port name 
 
   constant clock_period : time := 10 ns;
 
BEGIN
 
	-- Instantiate the Unit Under Test (UUT)
   uut: mux PORT MAP (
          i0 => i0,
          i1 => i1,
          i2 => i2,
          i3 => i3,
          i4 => i4,
          i5 => i5,
          i6 => i6,
          i7 => i7,
          c0 => c0,
          c1 => c1,
          c2 => c2,
          output => output
        );

 

   -- Stimulus process
   stim_proc: process
			variable count: std_logic_vector(7 downto 0) := (others => '0');
   begin	
	--------------
		WAIT FOR 5 ns;
		c0 <= '0';
		c1 <= '0';
		c2 <= '0';
	--------------
		WAIT FOR 5 ns;
		c0 <= '1';
		c1 <= '0';
		c2 <= '0';
	--------------
		WAIT FOR 5 ns;
		c0 <= '0';
		c1 <= '1';
		c2 <= '0';
	--------------
		WAIT FOR 5 ns;
		c0 <= '1';
		c1 <= '1';
		c2 <= '0';
	--------------
		WAIT FOR 5 ns;
		c0 <= '0';
		c1 <= '0';
		c2 <= '1';
	--------------
		WAIT FOR 5 ns;
		c0 <= '1';
		c1 <= '0';
		c2 <= '1';
	--------------
		WAIT FOR 5 ns;
		c0 <= '0';
		c1 <= '1';
		c2 <= '1';
	--------------
		WAIT FOR 5 ns;
		c0 <= '1';
		c1 <= '1';
		c2 <= '1';
		
		count := std_logic_vector(Unsigned(count)+1);
		
		i0 <= count(0);
		i1 <= count(1);
		i2 <= count(2);
		i3 <= count(3);
		i4 <= count(4);
		i5 <= count(5);
		i6 <= count(6);
		i7 <= count(7);
		
   end process;

END;
