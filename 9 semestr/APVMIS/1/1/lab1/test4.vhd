--------------------------------------------------------------------------------
-- Company: 
-- Engineer:
--
-- Create Date:   16:04:22 09/20/2015
-- Design Name:   
-- Module Name:   Y:/Desktop/1/lab1/test2.vhd
-- Project Name:  lab1
-- Target Device:  
-- Tool versions:  
-- Description:   
-- 
-- VHDL Test Bench Created by ISE for module: mux2
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
 
ENTITY test4 IS
END test4;
 
ARCHITECTURE behavior OF test4 IS 
 
    -- Component Declaration for the Unit Under Test (UUT)
 
    COMPONENT mux4
    PORT(
         i0 : IN  std_logic;
         i1 : IN  std_logic;
         i2 : IN  std_logic;
         i3 : IN  std_logic;
         i4 : IN  std_logic;
         i5 : IN  std_logic;
         i6 : IN  std_logic;
         i7 : IN  std_logic;
         c : IN  std_logic_vector(2 downto 0);
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
   signal c : std_logic_vector(2 downto 0) := (others => '0');

 	--Outputs
   signal output : std_logic;
   -- No clocks detected in port list. Replace <clock> below with 
   -- appropriate port name 
 
BEGIN
 
	-- Instantiate the Unit Under Test (UUT)
   uut: mux4 PORT MAP (
          i0 => i0,
          i1 => i1,
          i2 => i2,
          i3 => i3,
          i4 => i4,
          i5 => i5,
          i6 => i6,
          i7 => i7,
          c => c,
          output => output
        );

   -- Stimulus process
   stim_proc: process
			variable count: std_logic_vector(10 downto 0) := (others => '0');
   begin		
   --------------
		WAIT FOR 5 ns;
		
		
		count := std_logic_vector(Unsigned(count)+1);
		
		i0 <= count(0);
		i1 <= count(1);
		i2 <= count(2);
		i3 <= count(3);
		i4 <= count(4);
		i5 <= count(5);
		i6 <= count(6);
		i7 <= count(7);
		
		c(0) <= count(8);
		c(1) <= count(9);
		c(2) <= count(10);

   end process;

END;