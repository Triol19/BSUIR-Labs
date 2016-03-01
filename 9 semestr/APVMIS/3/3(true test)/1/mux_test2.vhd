--------------------------------------------------------------------------------
-- Company: 
-- Engineer:
--
-- Create Date:   13:46:01 10/18/2015
-- Design Name:   
-- Module Name:   Y:/Desktop/3/1/mux_test.vhd
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
USE ieee.std_logic_textio.ALL;
USE ieee.std_logic_unsigned.all;
LIBRARY std;
USE std.textio.ALL; 
 
-- Uncomment the following library declaration if using
-- arithmetic functions with Signed or Unsigned values
--USE ieee.numeric_std.ALL;
 
ENTITY mux_test2 IS
END mux_test2;
 
ARCHITECTURE behavior OF mux_test2 IS 
 
    -- Component Declaration for the Unit Under Test (UUT)
 
    COMPONENT mux
    PORT(
         i : IN  std_logic_vector(7 downto 0);
         c : IN  std_logic_vector(2 downto 0);
         output : OUT  std_logic
        );
    END COMPONENT;
	 
	 COMPONENT mux5
    PORT(
         i : IN  std_logic_vector(7 downto 0);
         c : IN  std_logic_vector(2 downto 0);
         output : OUT  std_logic
        );
    END COMPONENT;
    

   --Inputs
   signal i : std_logic_vector(7 downto 0) := (others => '0');
   signal c : std_logic_vector(2 downto 0) := (others => '0');
	
	signal i5 : std_logic_vector(7 downto 0) := (others => '0');
   signal c5 : std_logic_vector(2 downto 0) := (others => '0');

 	--Outputs
   signal output : std_logic;
	signal output5 : std_logic;
   -- No clocks detected in port list. Replace <clock> below with 
   -- appropriate port name 
 
BEGIN
 
	-- Instantiate the Unit Under Test (UUT)
   uut: mux PORT MAP (
          i => i,
          c => c,
          output => output
        );
		  
	uut5: mux5 PORT MAP (
          i => i5,
          c => c5,
          output => output5
        );
		  
   -- Stimulus process
   stim_proc: process
					file f : text;
					variable current_line : line;
					variable test_input : std_logic_vector(10 downto 0);
					variable line_error_number : integer := 1;
					variable is_any_error : boolean := false;
   begin		
		file_open(f, "mux_file_test.txt", READ_MODE);
		
		while not endfile(f) loop		
		   -- test input
			readline(f, current_line);
			read(current_line, test_input);
			c <= test_input(10 downto 8);
			i <= test_input(7 downto 0);
			
			c5 <= test_input(10 downto 8);
			i5 <= test_input(7 downto 0);
			
			readline(f, current_line); -- Skip line
			
			wait for 1 ns;
			if not (output = output5) then
				report "Error in test #" & integer'image(line_error_number);
				is_any_error := true;
			end if;
			line_error_number := line_error_number + 1;
		end loop;  
		
		file_close(f);
		
		if not is_any_error then
			report "No errors!";
		end if;
		assert false report "MY INTERRUPT. End of simulation." severity failure;
   end process;

END;
