package Day51;

import java.util.LinkedList;
import java.util.Queue;

public class PerfectNumbers {

	public static void main(String[] args) {
		String ans = solve(2);
		System.out.print(ans);
	}

	public static String solve(int A) {

		Queue<String> qu = new LinkedList<>();
		String ans = "";
		qu.add("1");
		qu.add("2");
		int count = 2;
		for (int i = 1; i < A; i++) {
			String str = qu.remove();
			if (count < A) {
				qu.add(str + "" + "1");
				qu.add(str + "" + "2");
				count += 2;
			}
		}
		StringBuilder sb = new StringBuilder(qu.peek());
		ans = qu.peek() + sb.reverse();
		return ans;
	}
}
